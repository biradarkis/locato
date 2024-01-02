using Ardalis.ApiEndpoints;
using Locato.API.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Admin
{
    [Route("/admin")]
    public class DisableUser : EndpointBaseAsync.WithRequest<long>.WithResult<JsonResult>
    {
        private readonly ISender _mediator;
        [HttpPost("disable")]
        public override async Task<JsonResult> HandleAsync(long request, CancellationToken cancellationToken = default)
        {
            var response  =  await _mediator.Send(new DisableUserCommand
            {
                UserId = request
            });

            return new JsonResult(new {Success  = response.Success , Error =response.Error});
        }
    }
}
