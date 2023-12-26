using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed : IApplicationContextSeed
    {
        private readonly IApplicationContext _context;
        private readonly ISender _mediator ;
        public async Task Seed(CancellationToken cancellationToken)
        {
         
        }
    }
}
