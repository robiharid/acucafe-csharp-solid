using System;
using System.Collections.Generic;
using System.Linq;

namespace AcuCafe.Drinks
{
    // plain old clr object (POCO), no logic, just data container
    public class Drink
    {
        public double Cost { get; set; }
        public IReadOnlyCollection<Topping> Toppings;
        public string Type { get; set; }
        public Drink(double cost, IReadOnlyCollection<Topping> toppings, string type)
        {
            Cost = cost;
            Toppings = toppings;
            Type = type;
        }

        public override string ToString()
        {
            //return $"Drink (£{Cost.ToString("N2")}): {Type} with Toppings: {string.Join(", ", Toppings)}";
            return $"Drink: {Type} with Toppings: {string.Join(", ", Toppings)}";
        }

    }
}
