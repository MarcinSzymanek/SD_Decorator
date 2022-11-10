namespace SD_DecoratorApp.Attributes;

public abstract class Attributes
{
    /*
     * Contains everything necessary to make 2 creatures fight each other to the death
     * This class must be overriden. *BaseAttributes classes just set the properties,
     * The BaseAttributes implementations of this class are the ones being decorated
     */
    
    public Attributes(string name, int hp, int damage, float speed, float modelScale)
    {
        Name = name;
        Hp = hp;
        Damage = damage;
        Speed = speed;
        ModelScale = modelScale;
    }
    public virtual string Name { get; protected set; }
    public virtual int Hp{get; private set; }
    public virtual int Damage{get; protected set;}
    public virtual float Speed{get; protected set;}
    public virtual float ModelScale{get; protected set;}
  
    public virtual int TakeDamage(int damage)
    {
        Hp -= damage;
        return damage;
    }
}