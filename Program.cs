using PooExercicesCS.Class;
using PooExercicesCS.Interface;

class Program
{
    static void Main(string[] args)
    {
        IPersonnage jo = new Personnage<Warrior>("Jo le Bourrin");
        IPersonnage sophana = new Personnage<Wizard>("Sophana le sorcier");
        IPersonnage justine = new Personnage<Cleric>("Juju la noob");
        IPersonnage mehdi = new Personnage<DemonLord>("Mehdi le roi démon");
        IPersonnage william = new Personnage<Bard>("William le Big Ben rat");


        jo.AddCapacity(new CoupDeBouleMystiqueDuBlaireau());
        jo.AddCapacity(new Mercurocrom());
        justine.AddCapacity(new CoupDeBouleMystiqueDuBlaireau());
        justine.AddCapacity(new Mercurocrom());
        sophana.AddCapacity(new DefenseBoost());
        sophana.AddCapacity(new FireBall());
        mehdi.AddCapacity(new DefenseBoost());
        mehdi.AddCapacity(new FireBall());
        mehdi.AddCapacity(new MagickBoost());
        mehdi.AddCapacity(new Maxi<FireBall>());
        william.AddCapacity(new ChantEnroué());


        mehdi.UseCapacity<MagickBoost>(mehdi);
        sophana.UseCapacity<DefenseBoost>(jo);
        mehdi.UseCapacity<Maxi<FireBall>>(jo);
        jo.UseCapacity<CoupDeBouleMystiqueDuBlaireau>(mehdi);
        justine.UseCapacity<Mercurocrom>(jo);
        mehdi.UseCapacity<FireBall>(jo);
        william.UseCapacity<ChantEnroué>(jo);
        jo.AddCapacity(new Maxi<CoupDeBouleMystiqueDuBlaireau>());
        jo.UseCapacity<Maxi<CoupDeBouleMystiqueDuBlaireau>>(mehdi);


    }
}