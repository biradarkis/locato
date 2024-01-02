using Locato.API.Application.Routes.Models;
using Locato.API.Application.Users.Models;
using Locato.Data.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Locato.API.Application.Routes.Commands
{
    public class AssignRouteCommand : IRequest<DefaultAPIResponse>
    {
        public AssignRouteRequest AssignRouteRequest { get; set; }
        public class AssignRouteCommandHandler : IRequestHandler<AssignRouteCommand, DefaultAPIResponse>
        {
            private readonly IApplicationDbContext _context;

            public AssignRouteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<DefaultAPIResponse> Handle(AssignRouteCommand request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.Where(x => request.AssignRouteRequest.UserIds.Contains(x.Id)).AsTracking().ToArrayAsync(cancellationToken);
                request.AssignRouteRequest.RouteName = request.AssignRouteRequest.RouteName.ToLower().Trim();
                var routeId = _context.Routes.Where(x => x.Name == request.AssignRouteRequest.RouteName).FirstOrDefault()?.Id;
                if (routeId == null)
                {
                    return new DefaultAPIResponse(error: "No route Found", false);
                }
                foreach (var user in users)
                {
                    user.RouteId = routeId;
                }

                await _context.SaveChangesAsync(cancellationToken);
                return new DefaultAPIResponse("", true, "successfully assigned routes");
            }
        }
    }
}
