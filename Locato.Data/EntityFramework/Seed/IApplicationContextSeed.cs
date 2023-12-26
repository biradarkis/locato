using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public interface IApplicationContextSeed
    {
        Task Seed(CancellationToken cancellationToken);
    }
}
