using Locato.Data.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.UserEntities
{
    public class Driver : User
    {
        public Driver() 
        {
           RoleId =(int) Roles.Driver;
        }
    }
}
