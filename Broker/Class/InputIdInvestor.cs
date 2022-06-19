using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
     public class InputIdInvestor
    {
        public static string Id { get; set; }
        public static string Input(string id)
        {
           Id= id;
           return id;
        }
    }
}
