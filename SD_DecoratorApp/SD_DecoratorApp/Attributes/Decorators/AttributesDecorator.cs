namespace SD_DecoratorApp.Attributes.Decorators;

public abstract class AttributesDecorator : Attributes
{
    /*
     * Base decorator class for attributes. Defines the interface for attribute-based decorators
     * References the inner Attributes object, truth be told I'm not sure if it should
     * But this version definitely works
     */
    private Attributes _attributes;

    public override string Name => _attributes.Name;

    public override int Damage => _attributes.Damage;

    public override int Hp => _attributes.Hp;
    public override float Speed => _attributes.Speed;

    public AttributesDecorator(Attributes attributes) : base(attributes.Name, attributes.Hp, attributes.Damage, attributes.Speed, attributes.ModelScale)
    {
        _attributes = attributes;
    }

    public override int TakeDamage(int damage)
    {
        return(_attributes.TakeDamage(damage));
    }
}
