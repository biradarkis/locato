using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Contracts
{
    public class TrackedEntity : Entity
    {
        public long CreatedBy { get;set; }
        public long ModifiedBy { get; set; }
    }
}
