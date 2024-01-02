using Ardalis.ApiEndpoints;
using Locato.API.Application.Users.Commands;
using Locato.API.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Useronboarding
{
    [Route("/auth")]
    public class ChangePassword : EndpointBaseAsync.WithRequest<ResetPasswordRequest>.WithActionResult<object>
    {
        private readonly ISender _mediator;

        public ChangePassword(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("changepassword")]
        [Authorize]
        public override async Task<ActionResult<object>> HandleAsync(ResetPasswordRequest request, CancellationToken cancellationToken = default)
        {
            var (Success, Error) = await _mediator.Send(new ResetPasswordCommand
            {
                ResetPasswordRequest = request
            }, cancellationToken);
            return new JsonResult(new { Success , Error});
        }
    }
}
