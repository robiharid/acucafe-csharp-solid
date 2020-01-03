namespace AcuCafe.Drinks
{
    public class DrinkType
    {
        public DrinkType(string name, double cost)
        {
            Name = name;
            BaseCost = cost;
        }

        public double BaseCost { get; set; }
        public string Name { get; set; }
    }
}
