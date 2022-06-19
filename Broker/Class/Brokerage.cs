using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Class
{
     class Brokerage
    {
        public string NameOfCompany { get; set; }
        public double CostOfPurchased { get; set; }
        public int Count { get; set; }
        public int EPS { get; set; }
        public double CurrentCost { get; set; }
        public Brokerage(string name_of_company, double cost_of_purchaesed, int count, int eps, double current_cost)
        {
            NameOfCompany = name_of_company;
            CostOfPurchased = cost_of_purchaesed;
            Count = count;
            EPS= eps;
            CurrentCost = current_cost;

        }

    }
}
