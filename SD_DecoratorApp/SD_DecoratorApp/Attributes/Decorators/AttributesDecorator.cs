namespace SD_DecoratorApp.Attributes.Decorators;

public abstract class AttributesDecorator : Attributes
{
    private Attributes _attributes;

    public override string Name
    {
        get
        {
            return _attributes.Name;
        }
    }

    public override int Damage { get => _attributes.Damage; }
    public override int Hp { get => _attributes.Hp; }
    public override float Speed
    {
        get => _attributes.Speed;
    }

    public override float ModelScale { get => _attributes.ModelScale; }

    public AttributesDecorator(Attributes attributes) : base(attributes.Name, attributes.Hp, attributes.Damage, attributes.Speed, attributes.ModelScale)
    {
        _attributes = attributes;
    }

    public override void TakeDamage(int damage)
    {
        _attributes.TakeDamage(damage);
    }
}
