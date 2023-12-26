using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Contracts
{
    internal interface IEntity
    {
        public long Id { get; set; }
        public DateTime Created { get;  internal set; }
        public DateTime Updated { get;  internal set; }

        public void OnCreated();
    }

    
}
