using Ardalis.ApiEndpoints;
using Locato.API.Application.Admin.Models;
using Locato.API.Application.Common.BulkUpload;
using Locato.API.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locato.API.Endpoints.Admin
{//todo add an permission attribute
    [Route("/admin")]
    public class AddVehicles : EndpointBaseAsync.WithRequest<UploadVehiclesRequest>.WithActionResult<DefaultAPIResponse>
    {
        private readonly ISender _mediator;
        
        public AddVehicles(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("uploadvehicles")]
        public override async Task<ActionResult<DefaultAPIResponse>> HandleAsync(UploadVehiclesRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new VehicleUploadCommand
            {

            });

            return response;
        }
    }
}
