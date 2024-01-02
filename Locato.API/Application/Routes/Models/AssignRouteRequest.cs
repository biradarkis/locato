namespace Locato.API.Application.Routes.Models
{
    public class AssignRouteRequest
    {
        public long[] UserIds { get; set; }
        public string RouteName { get; set; }
    }
}
