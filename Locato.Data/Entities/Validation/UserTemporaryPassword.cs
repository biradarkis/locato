using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Validation
{
    [Table("usertemppass")]
    public class UserTemporaryPassword : Entity
    {   
        public long BaseUserId { get;set; }
        public virtual BaseUser BaseUser { get;set; }   
        public required string Password { get;set; } 
        public DateTime ValidTill { get;set; } 
        public long CreatedById { get;set; }
        public virtual User CreatedBy { get;set; }
    }
    internal class UserTemporaryPasswordConfiguration : IEntityTypeConfiguration<UserTemporaryPassword>
    {
        public void Configure(EntityTypeBuilder<UserTemporaryPassword> builder)
        {
            builder.Property(x => x.Password).IsRequired();
            builder.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x=>x.CreatedById).IsRequired();
            builder.HasOne(x => x.BaseUser).WithMany().HasForeignKey(x => x.BaseUserId).IsRequired();
        }
    }
}
