using Locato.Data.EntityFramework;
using MediatR;
using Shared.Constants;

namespace Locato.API.Application.Users.Commands
{
    public class DisableUserCommand :IRequest<(string Error , bool Success)>
    {
        public long UserId { get; set; }
        public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, (string Error, bool Success)>
        {
            private readonly IApplicationDbContext _context;
            public DisableUserCommandHandler(IApplicationDbContext applicationDbContext) 
            {
               _context = applicationDbContext;
            }
            public async Task<(string Error, bool Success)> Handle(DisableUserCommand request, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(x => x.Id == request.UserId).FirstOrDefault();
                if(user == null) 
                {
                    return ("User not found \n please check the userid" , true);
                }
                user.AccountStatus = UserConstants.ACCOUNT_STATUS_DISABLED;
                return ("", true);
            }
        }
    }
}
