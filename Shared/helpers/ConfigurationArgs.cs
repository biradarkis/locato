using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.helpers
{
    public class ConfigurationArgs
    {
        public bool EnableApi { get; set; }

        public bool EnableWorker { get; set; }

        public bool CreateDb { get; set; }

        public bool SeedDb { get; set; }

        public bool DeleteDb { get; set; }
    }
}
