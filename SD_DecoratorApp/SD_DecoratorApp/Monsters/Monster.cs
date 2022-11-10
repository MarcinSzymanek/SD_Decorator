using SD_DecoratorApp.Attributes;

namespace SD_DecoratorApp.Monsters;
/*
 * Simplistic game object class
 * Contains attributes, a function to take damage and to check if it is dead
 * Decorating happens to _attributes in MonsterController
 */
public class Monster
{
    private Attributes.Attributes _attributes;
    public Monster(Attributes.Attributes attributes)
    {
        _attributes = attributes;
    }

    public Monster()
    {
        _attributes = new MonsterBaseAttributes();
    }
    public int OnTakeDamage(int dmg)
    {
        return(_attributes.TakeDamage(dmg));
    }

    // Untested and unused
    public void Buff(Attributes.Attributes attr)
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

    // Needed by UI and game logic
    public Attributes.Attributes GetAttributes()
    {
        return _attributes;
    }


}