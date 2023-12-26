using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Validation
{
    public class UserOTP : Entity
    {
        public long UserId { get; set; }
        public int Otp { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }

    internal class UserOTPConfiguration : IEntityTypeConfiguration<UserOTP>
    {
        public void Configure(EntityTypeBuilder<UserOTP> builder)
        {
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired();
            builder.Property(x=>x.ExpiryDate).IsRequired();
            builder.Property(x=>x.Otp).IsRequired();
        }
    }
}
