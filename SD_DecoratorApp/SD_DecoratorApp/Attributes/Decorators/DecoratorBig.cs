namespace SD_DecoratorApp.Attributes.Decorators;

public class DecoratorBig : AttributesDecorator
{
    public override string Name
    {
        get => "Big " + base.Name;
    }

    public override int Damage
    {
        get => base.Damage + 2;
    }

    public override int Hp
    {
        get => (int)(base.Hp + 5);
    }

    public DecoratorBig(Attributes attributes) : base(attributes)
    {

    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}