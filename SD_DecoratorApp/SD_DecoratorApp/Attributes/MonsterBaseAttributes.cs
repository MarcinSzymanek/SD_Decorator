namespace Character
{
    public class MonsterBaseAttributes : Attributes
    {
        public override string Name { get; protected set; } 
        public override int Hp { get; protected set;} 
        public override float Speed { get; protected set;} 
        public override int Damage { get; protected set;} 
        public override float ModelScale { get; protected set;}

        public MonsterBaseAttributes()
        {
            SetAttributes("Monster", 10, 1, 1.0f, 1.0f);
        }
        
        public override void SetAttributes(string name, int hp, int dmg, float spd, float scale)
        {
            Name = name;
            Hp = hp;
            Speed = spd;
            Damage = dmg;
            ModelScale = scale;
        }
    }
}