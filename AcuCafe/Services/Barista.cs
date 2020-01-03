using AcuCafe.Drinks;
using System;
using System.Collections.Generic;

namespace AcuCafe
{
    public class Barista
    {
        // could have passed in DrinkBuilder as argument to constructor to demonstrate DI, but not neccessary
        // and would also mean the ctor is empty apart from builder assignment 
        // Barista uses facade pattern
        private IDrinkBuilder _drinkBuilder;
        private List<Drink> _customerOrders = new List<Drink>();

        public Barista(IDrinkBuilder drinkBuilder)
        {
            _drinkBuilder = drinkBuilder;
        }
        public Drink OrderDrink(DrinkType drinkType, List<Topping> toppings)
        {
            _drinkBuilder.init();
            // REMOVE _drinkBuilder = new DrinkBuilder();
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
