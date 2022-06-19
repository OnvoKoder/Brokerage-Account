using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
    class GetNameCompany
    {
        public static string NameCompany { get; set; }
        public static string Get(string Name)
        {
            NameCompany = Name;
            return Name;
        }
    }
}
