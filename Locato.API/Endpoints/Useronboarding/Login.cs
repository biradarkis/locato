using Ardalis.ApiEndpoints;
using Locato.API.Application.Users.Commands;
using Locato.API.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Useronboarding
{
    [Route("/login")]
    [AllowAnonymous]
    public class Login : EndpointBaseAsync.
         WithRequest<LoginUserCommand>
        .WithResult<ActionResult<LoginResponse>>
    {
        private readonly ISender _mediator;
        public Login(ISender mediator)
        {
            _mediator = mediator;   
        }
        [HttpPost()]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginUserCommand request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return new JsonResult(response);
        }
    }
}
