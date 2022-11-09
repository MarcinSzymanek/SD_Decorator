using Decorator_test;

//MonsterAttributes m1 = new MonsterAttributes("monster 1", 100, 4, 2.9f, 1.0f);
MonsterAttributes m1 = new MonsterAttributes(
    "Orc","Warchief1",200,14,157,1.25f);
MonsterAttributes m2 = new MonsterAttributes(
    "Orc","Warchief2",200,14,157,1.25f);
m1.Print();

DecoratorBig Db = new DecoratorBig(m1,1.5f);
Db.SetAttributes(m1);
m1.Print();
m2.Print();

m1.TakeDamage(10);
DecoratorArmor Da = new DecoratorArmor(m1, 10);
m1.Print();
Da.TakeDamage(100);
m1.Print();
