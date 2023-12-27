using InfraStructure.Services.Interfaces;
using Locato.Data.Entities.UserEntities;
using Locato.Data.EntityFramework;
using Locato.Web.Application.Users.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Locato.Web.Application.Users.Commands
{
    public class LoginUserCommand:IRequest<LoginResponse>
    {
        public required string UserId { get; set; }
        public required string IdType { get;set; }
        public required string Password { get;set; }

        public class Handler : IRequestHandler<LoginUserCommand, LoginResponse>
        {
            private readonly IApplicationDbContext _context;
            private readonly IJwtHandler _jwtHandler;

            public Handler(IApplicationDbContext context  , IJwtHandler jwtHandler)
            {
                _context = context;
                _jwtHandler = jwtHandler;
            }
            public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                //todo inserto token 
                User user;
                if (request.IdType == "Phone")
                {
                    user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Phone.RawInput == request.UserId, cancellationToken);
                } else
                {
                    user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == request.UserId, cancellationToken);
                }


                if (user != null && user.MatchPassword(request.Password))
                {
                    
                    
                        var token = _jwtHandler.GenerateJwtToken(user);
                        var refreshtocken = _jwtHandler.GenerateJwtRefreshToken(user);
                        return new LoginResponse(user, token, refreshtocken);
                    
                    
                } else
                {
                  return new LoginResponse("Invalid Username or Password");
                }
            }
        }
    }
}
