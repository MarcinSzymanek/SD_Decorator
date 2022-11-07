using Character;
using Character.Decorators;

namespace SD_DecoratorApp.Monsters;

public class Monster
{
    private Attributes _attributes;
    public Monster(Attributes attributes)
    {
        _attributes = attributes;
    }

    public Monster()
    {
        _attributes = new MonsterBaseAttributes();
    }
    public void OnTakeDamage(int dmg)
    {
        _attributes.TakeDamage(dmg);
    }

    public void Buff(Attributes attr)
    {
        _attributes = attr;
    }

    // Needed for gamestate
    public bool CheckIfDead()
    {
        if (_attributes.Hp < 1)
        {
            return true;
        }

        return false;
    }

    // Needed for UI to display attributes
    public Attributes GetAttributes()
    {
        return _attributes;
    }


}