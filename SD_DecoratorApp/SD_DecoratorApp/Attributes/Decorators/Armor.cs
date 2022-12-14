namespace SD_DecoratorApp.Attributes.Decorators;

public class Armor : AttributesDecorator
{
     /*
      * Makes a monster take less damage by reducing incoming dmg in TakeDamage
      * method before calling base version of this method
      */
    private readonly int _armor;
    public override string Name
    {
        get => "Armored " + base.Name;
    }
    public Armor(Attributes attributes, int armor) : base(attributes)
    {
        _armor = armor;

    }

    public override int TakeDamage(int damage)
    {
        int dmgTaken = (damage - _armor);
        if (damage - _armor < 0)
        {
            dmgTaken = 0;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Blocked: " + _armor);
        Console.ForegroundColor = ConsoleColor.White;
        return(base.TakeDamage(dmgTaken));
    }
        
}