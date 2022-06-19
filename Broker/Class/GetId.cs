using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
    public class GetId
    {
        public static string Id { get; set; }
        public static string Get(string id)
        {
            Id = id;
            return id;
        }
    }
}
