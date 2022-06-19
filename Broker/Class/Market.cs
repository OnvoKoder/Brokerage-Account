using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
     class Market
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Segment { get; set; }
        public double Cost { get; set; }
        public double Denomination { get; set; }
        public int EPS { get; set; }
        public Market( string name, string description, string segment, double cost, double denomination, int eps )
        {
            Name=name;
            Description=description;
            Segment=segment;
            Cost=cost;
            Denomination=denomination;
            EPS=eps;
        }
    }
}
