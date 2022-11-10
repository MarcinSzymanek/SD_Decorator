namespace SD_DecoratorApp.Attributes.Decorators;

public class CriticalChance : AttributesDecorator
{
    /*
     * Adds a random critical damage functionality, by overriding base Damage property
     * getter
     */
    private readonly Random _rand = new Random();
    public override string Name
    {
        get => "Critical  " + base.Name;
    }
    public override int Damage {
        get
        {
            int dice = _rand.Next(100);
            if (dice < 25)
            {
                Console.ForegroundColor = ConsoleColor.White;
                return (base.Damage+1) * 2;
            }

            return base.Damage + 1;
        }
    }
    public CriticalChance(Attributes attributes) : base(attributes)
    {
            
    }

}