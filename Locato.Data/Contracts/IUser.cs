using Locato.Data.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Contracts
{
    public interface IUser
    {
        string Password { get;  }   
        string Email { get; }
        Phone Phone { get; }
    }
}
