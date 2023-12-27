using Locato.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Business
{
    public class OrganizationShift : TrackedEntity
    {
        public long OrganizationId { get;set; }
        public Organization Organization { get;set; }
        public DateTime  From { get;set; }
        public DateTime  To { get;set; }
    }

    internal class OrganizationShiftConfiguration : IEntityTypeConfiguration<OrganizationShift>
    {
        public void Configure(EntityTypeBuilder<OrganizationShift> builder)
        {
            builder.HasOne(x=>x.Organization).WithMany(x=>x.Shifts).HasForeignKey(x=>x.OrganizationId);
        }
    }
}
