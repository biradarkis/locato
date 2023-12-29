using InfraStructure.Services.Interfaces;
using Locato.API.Application.Users.Models;
using Locato.API.Application.Users.Queries;
using Locato.Data.EntityFramework;
using MediatR;

namespace Locato.API.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<LoginResponse>
    {
        public CreateNewUserCommand CreateNewUserCommand { get; set; }

        public class Handler : IRequestHandler<RegisterUserCommand, LoginResponse>
        {
            private readonly IApplicationDbContext _context;
            private readonly ISender _mediator;
            private readonly IJwtHandler _jwtHandler;

            public Handler(IApplicationDbContext context , ISender mediator, IJwtHandler jwtHandler)
            {
                _context = context;
                _mediator = mediator;
                _jwtHandler=jwtHandler;
            }
            public async Task<LoginResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var emailOrPhoneExist = await _mediator.Send(new CheckEmailOrPhoneExistQuery
                {
                    Email = request.CreateNewUserCommand.Email,
                    PhoneNumber = request.CreateNewUserCommand.Phone.RawInput
                });

                if ((RegisterResult)emailOrPhoneExist==RegisterResult.EMAIL_EXISTS)
                {
                    return new LoginResponse("user with this email already exists");
                }
                
                if ((RegisterResult)emailOrPhoneExist==RegisterResult.PHONE_EXISTS)
                {
                    return new LoginResponse("user with this phone already exists");
                }

                var user = await _mediator.Send(request.CreateNewUserCommand,cancellationToken);
                var token  = _jwtHandler.GenerateJwtToken(user);
                var refreshtoken  = _jwtHandler.GenerateJwtRefreshToken(user); 

                return new LoginResponse(user , token, refreshtoken);
            }
        }
    }
}
