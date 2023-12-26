using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locato.Data.Entities.Communication
{
    [Index( nameof(Status))]
    public class PushNotification : Entity
    {
        public string Type { get; set; }
        public string Message { get; set; }

        
        public string Status { get; set; }

        public string MetaStringified { get; set; }

        public dynamic Meta
        {
            get => JsonConvert.DeserializeObject(MetaStringified, SerializerSettings);
            set { MetaStringified = JsonConvert.SerializeObject(value, SerializerSettings); }
        }

        public short Retries { get; set; }

        public long FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public long ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        public PushNotification()
        {
            Status = NotificationStatus.Created.ToString();

            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });

        }

        protected JsonSerializerSettings SerializerSettings { get; set; }
    }

    public enum NotificationStatus
    {
        Created,
        Sent,
        Failed
    }

    public class PushNotificationTypeConfiguration : IEntityTypeConfiguration<PushNotification>
    {
        public void Configure(EntityTypeBuilder<PushNotification> builder)
        {
            builder.Ignore(x => x.Meta);
            builder.Property(x => x.MetaStringified).HasColumnName("Meta");
            builder.HasOne(x => x.FromUser).WithMany().HasForeignKey(x => x.FromUserId).IsRequired();
            builder.HasOne(x => x.ToUser).WithMany().HasForeignKey(x => x.ToUserId).IsRequired();
        }
    }
}
