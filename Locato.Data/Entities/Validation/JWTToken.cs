using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Validation
{
    [Table("JWTTokens")]
    public class JWTToken : Entity
    {
        public long UserId { get;set; }
        public User User { get;set; }
        /// <summary>
        /// <see cref="TokenType"/>
        /// </summary>
        public string Type { get;set; }
        public string Token { get;set; }
    }

    public enum TokenType
    {
        JWTTOKEN,
        JWTREFRESHTOKEN
    }
}
