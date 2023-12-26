using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Communication
{
    public class SmsNotification : Entity, IValidatableObject
    {
        public string Sender { get; set; }

        /// <summary>
        /// The E.164 format number of receiver.
        /// </summary>
        /// <remarks>E.164 numbers can have a maximum of fifteen digits and are usually written as follows: [+][country code][subscriber number including area code].</remarks>
        public string Recipient { get; set; }

        public long ToUserId { get; set; }
        public virtual User User { get; set; }

        public bool IsUniCodeSms { get; set; }

        /// <summary>
        /// Actual Sms Message. Can be longer than standard 160 char limit.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Notification Status - Created, Sent, Failed etc.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// An UUID received as part of response from provider.
        /// </summary>
        public string ProviderGeneratedId { get; set; }

        public int Retries { get; set; }
        /// <summary>
        /// <see cref="SMSProvier"/>
        /// </summary>
        public string SmsProvider { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                return Array.Empty<ValidationResult>();  
        }
    }
    public enum SMSProvier
    {
        MSG91,   // India
        InfoBip, //Tanzania
        MetrolTel
    }
}   
