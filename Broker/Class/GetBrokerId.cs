using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
    public class GetBrokerId
    {
        public static string IdBr { get; set; }
        public static string GetBr(string id)
        {
            IdBr = id;
            return id;
        }
    }
}
