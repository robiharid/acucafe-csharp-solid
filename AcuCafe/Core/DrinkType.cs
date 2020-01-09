namespace AcuCafe.Drinks
{

    //originally did this as enum, misread the spec as i thought
    //you were asking for extensibility in a different way,
    //and that you could have also simply just added differente enums
    //because stringly type wouldnt go in prod
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
