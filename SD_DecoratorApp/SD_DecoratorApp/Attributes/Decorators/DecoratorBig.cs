namespace SD_DecoratorApp.Attributes.Decorators
{
    public class DecoratorBig : AttributesDecorator
    {
        /*
         * Makes the monster stronger and tougher by overriding damage and hp getters
         */
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

    }
}