using NUnit.Framework;
using AcuCafe;
using AcuCafe.Drinks;
using System.Collections.Generic;

namespace AcuCafeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddChocolateToppingToExpresso()
        {
            DrinkBuilder drinkBuilder = new DrinkBuilder();
            Barista helen = new Barista(drinkBuilder);

            var expresso = new DrinkType("Expresso", 1.5);
            var chocolate = new Topping("Chocolate", 0.5);


            var chocExpressoToppings = new List<Topping>() { chocolate };

            // should add method overloads so that list and single topping can be accepted
            var chocExpressoDrink = helen.OrderDrink(expresso, chocExpressoToppings);

            Assert.AreEqual(chocExpressoDrink.ToString(), "Drink: Expresso with Toppings: Chocolate");

        }

        [Test]
        public void StopIcedTeaWithMilkOrder()
        {
            DrinkBuilder drinkBuilder = new DrinkBuilder();
            Barista helen = new Barista(drinkBuilder);
            var tea = new DrinkType("Tea", 1.5);
            var icedTea = new DrinkType("Iced Tea", 1.5);

            var milk = new Topping("Milk", 0.5);
            var sugar = new Topping("Sugar", 0.5);

            var jonsToppings = new List<Topping>() { milk, sugar };
            var jonsDrinkTea = helen.OrderDrink(tea, jonsToppings);

            var robisToppings = new List<Topping>() { milk };
            var robisDrinkIcedTea = helen.OrderDrink(icedTea, robisToppings);

            helen.PrepareDrink(jonsDrinkTea);
            helen.PrepareDrink(robisDrinkIcedTea);

            helen.StopOrder(robisDrinkIcedTea);

            var completeDrinks = helen.ServeDrinkOrders();


            Assert.IsFalse(completeDrinks.Contains(robisDrinkIcedTea));
        }
    }
}