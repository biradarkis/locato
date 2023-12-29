using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string RefreshSecret { get; set; }
        public string FrontEndUrl { get; set; }
      
    }
}
