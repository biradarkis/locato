using Ardalis.ApiEndpoints;
using Locato.API.Application.Users.Commands;
using Locato.API.Application.Users.Models;
using Locato.Data.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Useronboarding
{
    [Route("/auth")]
    public class Register : EndpointBaseAsync.WithRequest<RegisterUserCommand>.WithActionResult<LoginResponse>
    {
        private readonly ISender _mediator;

        public Register(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/register")]
        public async override Task<ActionResult<LoginResponse>> HandleAsync(RegisterUserCommand request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request);
            return new JsonResult(response);
        }
    }
}
