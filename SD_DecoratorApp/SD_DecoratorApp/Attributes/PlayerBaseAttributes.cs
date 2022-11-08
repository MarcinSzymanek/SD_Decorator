namespace SD_DecoratorApp.Attributes
{
    public class PlayerBaseAttributes : Attributes
    {

        public PlayerBaseAttributes()
        {
            SetAttributes("Player", 20, 2, 1.0f, 1.0f);
        }

        public void SetAttributes(string name, int hp, int dmg, float spd, float scale)
        {
            Name = name;
            Hp = hp;
            Speed = spd;
            Damage = dmg;
            ModelScale = scale;
        }
    }
}