using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
    public class GetName
    {
        public static string Name { get; set; }
        public static string Get(string name)
        {
            Name = name;
            return name;
        }
    }
}
