using PooExercicesCS.Class;
using PooExercicesCS.Interface;

class Program
{
    static void Main(string[] args)
    {
        IPersonnage jo = new Personnage<Warrior>("Jo le Bourrin");
        IPersonnage sophana = new Personnage<Wizard>("Sophana le pas Clerc");
        IPersonnage medhi = new Personnage<Cleric>("Medhi le presque magicien");


        jo.AddCapacity(new CoupDeBouleMystiqueDuBlaireau());
        sophana.AddCapacity(new DefenseBoost());
        medhi.AddCapacity(new FireBall());
        medhi.AddCapacity(new MagickBoost());
        medhi.AddCapacity(new Maxi<FireBall>());


        medhi.UseCapacity<MagickBoost>(medhi);
        sophana.UseCapacity<DefenseBoost>(jo);
        medhi.UseCapacity<Maxi<FireBall>>(jo);
        jo.UseCapacity<CoupDeBouleMystiqueDuBlaireau>(medhi);
    }
}