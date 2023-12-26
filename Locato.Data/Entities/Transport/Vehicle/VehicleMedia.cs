using Locato.Data.Contracts;
using Locato.Data.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntities
{
    public class VehicleMedia : Entity, IValidatableObject
    {
        public long VehicleId{ get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public long FileId { get; set; }
        public virtual StaticMedia File { get; set; }

        /// <summary>
        /// <see cref="VehicleMediaType"/>
        /// </summary>
        public string Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();       
        }


    }

    public enum VehicleMediaType
    {
        RC,
        TaxCertificate,
        Insurance,
        Permit,
        OrgPermit,
        FitnessCertificate,
        BusBranding
    }

    internal class VehicleMediaConfiguration : IEntityTypeConfiguration<VehicleMedia>
    {
        public void Configure(EntityTypeBuilder<VehicleMedia> builder)
        {
            builder.HasOne(x => x.Vehicle).WithMany(x => x.Media).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(x=>x.File).WithOne().OnDelete(DeleteBehavior.ClientSetNull).IsRequired();     
        }
    }
}
