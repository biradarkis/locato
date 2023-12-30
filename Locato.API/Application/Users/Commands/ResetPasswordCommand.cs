using Locato.API.Application.Users.Models;
using Locato.Data.EntityFramework;
using MediatR;
using Services.Interfaces;

namespace Locato.API.Application.Users.Commands
{
    public class ResetPasswordCommand :IRequest<(bool Success , string Error)>
    {
        public ResetPasswordRequest ResetPasswordRequest { get; set; }
       
        internal class Handler : IRequestHandler<ResetPasswordCommand,(bool Success , string Error)> 
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger _logger;
            private ICurrentUserService _currentUserService;

            public Handler(IApplicationDbContext context,  ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<(bool Success, string Error)> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                var userId = _currentUserService.UserId;
                var user  = _context.Users.FirstOrDefault(x=>x.Id == userId);
                if (user != null && user.MatchPassword(request.ResetPasswordRequest.CurrentPassword))
                {
                    user.UpdatePassword(request.ResetPasswordRequest.NewPassword);
                    // when generating next refresh token validate this
                    user.ClearToken = DateTime.UtcNow;
                    await _context.SaveChangesAsync(cancellationToken);
                    return (true, "");
                }
                else
                {
                    return (false, "User's Current Password Doesn't Match");
                }

            }
        }
    }
}
