namespace Character
{
    public class MonsterBaseAttributes : Attributes
    {

        public MonsterBaseAttributes()
        {
            SetAttributes("Monster", 10, 1, 1.0f, 1.0f);
        }
        
        public void SetAttributes(string name, int hp, int dmg, float spd, float scale)
        {
            Name = name;
            Hp = hp;
            Speed = spd;
            Damage = dmg;
            ModelScale = scale;
        }

        public override void TakeDamage(int dmg)
        {
            Hp = Hp - dmg;
        }
    }
}