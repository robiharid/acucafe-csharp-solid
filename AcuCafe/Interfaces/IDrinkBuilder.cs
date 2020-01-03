namespace AcuCafe.Drinks
{
    public interface IDrinkBuilder
    {
        void SetType(DrinkType type);
        void AddTopping(Topping topping);
    }
}
