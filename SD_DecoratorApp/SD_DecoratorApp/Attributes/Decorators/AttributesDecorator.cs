namespace SD_DecoratorApp.Attributes.Decorators;

public abstract class AttributesDecorator : Attributes
{
    private Attributes _attributes;

    public override string Name => _attributes.Name;

    public override int Damage => _attributes.Damage;

    public override int Hp => _attributes.Hp;
    public override float Speed => _attributes.Speed;

    public AttributesDecorator(Attributes attributes) : base(attributes.Name, attributes.Hp, attributes.Damage, attributes.Speed, attributes.ModelScale)
    {
        _attributes = attributes;
    }

    public override void TakeDamage(int damage)
    {
        _attributes.TakeDamage(damage);
    }
}
