using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcuCafe.Drinks
{
    public class Topping
    {
        public Topping(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
