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
            _drinkBuilder.Init();
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

        public List<Drink> ServeDrinkOrders()
        {
            List<Drink> _finalOrders = new List<Drink>(_customerOrders);
            _customerOrders.Clear(); //clear doesnt resize array, only frees up members for garb collect

            // would remove this for debug, dont need side effects
            foreach (Drink order in _finalOrders)
            {
                Console.WriteLine($"Serving order: {order.ToString()}");
            }
            return _finalOrders;
        }

        public void StopOrder(Drink incorrectDrink)
        {
            if (!_customerOrders.Contains(incorrectDrink)) return;
            _customerOrders.Remove(incorrectDrink);
            Console.WriteLine($"Removing order: {incorrectDrink}");
        }

    }
}
