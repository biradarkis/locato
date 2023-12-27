using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public interface IApplicationDbContextSeed
    {
        Task Seed(CancellationToken cancellationToken);
    }
}
