using Locato.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Audit
{
    public class DeletedEntity : TrackedEntity
    {
        public string Meta { get; set; }
        public string Type { get;set; }
    }
}
