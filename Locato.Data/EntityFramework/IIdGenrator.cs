using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework
{
    public interface IIdGenerator<T> : IEnumerable<T>
    {
        /// <summary>
        /// Generates new identifier every time the method is called
        /// </summary>
        /// <returns>new identifier</returns>
        T GenerateId();
    }
   
}
