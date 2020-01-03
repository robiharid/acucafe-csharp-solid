using System.Collections.Generic;

namespace AcuCafe.Drinks
{
    public interface IDrinkBuilder
    {
        void SetType(DrinkType type);
        void AddTopping(Topping topping);
        Drink Build();
        void init();
    }

    public class DrinkBuilder : IDrinkBuilder
    {
        private double _cost;
        private List<Topping> _toppings;
        private string _type;
        public DrinkBuilder()
        {
            _cost = 0;
            _toppings = new List<Topping>();
            _type = string.Empty;
        }

        // neccessary to reset DrinkBuilder if using DI to allow for tests
        public void init() 
        {
            _cost = 0;
            _toppings = new List<Topping>();
            _type = string.Empty;
        }

        public void SetType(DrinkType type)
        {
            _type = type.Name;
            _cost += type.BaseCost;
        }

        public void AddTopping(Topping topping)
        {
            _toppings.Add(topping);
            _cost += topping.Cost;
        }
        public Drink Build()
          => new Drink(_cost, _toppings, _type);


    }

}

