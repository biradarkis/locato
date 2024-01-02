using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationDbContextSeed : IApplicationDbContextSeed
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator ;
        public ApplicationDbContextSeed(IApplicationDbContext context , ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task Seed(CancellationToken cancellationToken)
        {
            await SeedOrganization(cancellationToken);
            await SeedOrganizationShifts(cancellationToken);
            await SeedProfiles(cancellationToken); 
            await SeedPhotos(cancellationToken);
            await SeedRoutes(cancellationToken);
            await SeedUsers(cancellationToken); 
        }

    }
}
