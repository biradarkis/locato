using Locato.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.UserEntities
{
    public class UserDeviceInfo : Entity, IValidatableObject
    {
        /// <summary>
        /// APNS token for Apple or GCM Registration token for Android.
        /// </summary>
        public string DeviceToken { get; set; }

        /// <summary>
        /// Device OS Version
        /// </summary>
        public string OsVersion { get; set; }

        /// <summary>
        /// Device Type - Apple, Android, WindowsPhone etc.
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// Navigational property to the Principal.
        /// </summary>
        public long UserId { get; set; }    
        public virtual User User { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class UserDeviceInfoConfiguration : IEntityTypeConfiguration<UserDeviceInfo>
    {
        public void Configure(EntityTypeBuilder<UserDeviceInfo> builder)
        {
            builder.HasOne(x=>x.User).WithMany(x=>x.UserDevices).HasForeignKey(x=>x.UserId);
        }
    }
}
