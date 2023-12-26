using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Scheduling
{
    public class OrganizationOffDay : Entity
    {
        public DayOfWeek OffDay { get;set; }
        public Organization Organization { get;set; }
        public long OrganizationId { get;set; }
    }
}
