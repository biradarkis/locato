using Ardalis.ApiEndpoints;
using Locato.API.Application.Routes.Models;
using Locato.API.Application.Users.Models;
using Locato.API.Application.Routes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Admin
{
    [Route("/admin")]
    public class AssignRoute : EndpointBaseAsync.WithRequest<AssignRouteRequest>.WithActionResult<DefaultAPIResponse>
    {
        private readonly ISender _mediator;
        public AssignRoute(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("assignroute")]
        public override async Task<ActionResult<DefaultAPIResponse>> HandleAsync(AssignRouteRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new   AssignRouteCommand
            {
                AssignRouteRequest = request
            });
            return response;
        }
    }
}
