using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Components;

namespace Locato.API.Endpoints.Useronboarding
{
    [Route("/auth")]
    public class Register :EndpointBaseAsync.WithRequest<>
    {
    }
}
