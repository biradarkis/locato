using InfraStructure.Services.Interfaces;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Entities.Validation;
using Locato.Data.EntityFramework;
using Locato.Web.Application.Users.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Locato.Web.Application.Users.Validators;
using Locato.Data.Contracts;
using Newtonsoft.Json.Linq;

namespace Locato.Web.Application.Users.Commands
{       /// <summary>
        ///  See Validation <see cref="LoginUserCommandValidator"/>
        /// </summary>
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
                
                User? user;
                if (request.IdType == "Phone")
                {
                    user = await _context.Users.Include(x=>x.Profile).Include(x=>x.Profile.Photo).AsNoTracking().FirstOrDefaultAsync(x => x.Phone.RawInput == request.UserId, cancellationToken);
                } else
                {
                    user = await _context.Users.Include(x => x.Profile).Include(x => x.Profile.Photo).AsNoTracking().FirstOrDefaultAsync(x => x.Email == request.UserId, cancellationToken);
                }

                if (user != null && user.MatchPassword(request.Password))
                {
                        var token = _jwtHandler.GenerateJwtToken(user);
                        var refreshtocken = _jwtHandler.GenerateJwtRefreshToken(user);
                        await InsertTokens(token, refreshtocken ,user);
                        return new LoginResponse(user, token, refreshtocken);
                } 
                else
                {
                  return new LoginResponse("Invalid Username or Password");
                }
            }

            private async Task InsertTokens(string token , string refreshtoken , User user)
            {
                await _context.JWTTokens.AddAsync(new JWTToken
                {
                    Token = token,
                    Type = TokenType.JWTTOKEN.ToString(),
                    UserId = user.Id,
                }, default);

                await _context.JWTTokens.AddAsync(new JWTToken
                {
                    Type = TokenType.JWTREFRESHTOKEN.ToString(),    
                    Token = refreshtoken,
                    UserId = user.Id
                }, default);

               await _context.SaveChangesAsync(default);
            }
        }
    }
}
