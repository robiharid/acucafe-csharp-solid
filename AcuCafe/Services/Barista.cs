using AcuCafe.Drinks;
using System;
using System.Collections.Generic;

namespace AcuCafe
{
    public class Barista
    {
        private DrinkBuilder _drinkBuilder;
        // orders are asking for logical queue
        private List<Drink> _customerOrders = new List<Drink>();
        public Drink OrderDrink(DrinkType drinkType, List<Topping> toppings)
        {
            _drinkBuilder = new DrinkBuilder();
            _drinkBuilder.SetType(drinkType);

            foreach(Topping topping in toppings)
            {
                _drinkBuilder.AddTopping(topping);
            }
            return _drinkBuilder.Build();
        }

        public void PrepareDrink(Drink drink)
        {
            _customerOrders.Add(drink);
        }

        public void ServeDrinkOrders()
        {
            foreach (Drink order in  _customerOrders){
                Console.WriteLine($"Serving order: {order.ToString()}");
            }
            _customerOrders.Clear(); //clear doesnt resize array, only frees up members for garb collec
        }

        public void StopOrder(Drink incorrectDrink)
        {
            if (!_customerOrders.Contains(incorrectDrink)) return;
            _customerOrders.Remove(incorrectDrink);
            Console.WriteLine($"Removing order: {incorrectDrink}");
        }
    }
}
