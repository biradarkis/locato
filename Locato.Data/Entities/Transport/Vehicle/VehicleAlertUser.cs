using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntities
{
    public class VehicleAlertUser : Entity
    {
        public long AlertId { get; set; }
        public virtual VehicleAlert Alert { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public DateTimeOffset? ReadOn { get; set; }
    }
}
