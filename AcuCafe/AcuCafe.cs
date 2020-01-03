using AcuCafe.Drinks;
using System;
using System.Collections.Generic;

namespace AcuCafe
{
    public class AcuCafe
    {
        public static void Main(string[] args)
        {
            // needs to consider if Type/Topping price changes i.e. tea becomes 2.0
            // might want to mislabel a customers name later on

            // would have typed Toppings and Drinks as Enum but we need to have flexibility adding and  
            // removing, stringly typed it is

            // would also wrap statements in tryc / finally or using blocks and add exception handling
            Barista helen = new Barista();
            var tea = new DrinkType("Tea", 1.5);

            var milk = new Topping("Milk", 0.5);
            var sugar = new Topping("Sugar", 0.5);

            var jonsToppings = new List<Topping>() { milk, sugar };
            var jonsDrink = helen.OrderDrink(tea, jonsToppings);

            var robisToppings = new List<Topping>() { milk };
            var robisDrink = helen.OrderDrink(tea, robisToppings);

            helen.PrepareDrink(jonsDrink);
            helen.PrepareDrink(robisDrink);

            helen.StopOrder(jonsDrink);

            helen.ServeDrinkOrders();
            Console.ReadLine();
        }        
    }
}