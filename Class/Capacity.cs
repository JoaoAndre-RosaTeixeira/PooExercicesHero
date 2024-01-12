using PooExercicesCS.Enum;
using PooExercicesCS.Interface;

namespace PooExercicesCS.Class
{

    public class Maxi<T> : ICapacity where T : ICapacity, new()
    {
        public T CapaciteDeBase { get; set; }
        public string CapacityName { get; set; } = "Maxi ";
        public double PowerUp { get; set; } = 1.5;

        public Maxi() 
        {
            CapaciteDeBase = new T();
            CapaciteDeBase.CapacityName = CapacityName + CapaciteDeBase.CapacityName;
            CapaciteDeBase.PowerUp = PowerUp;
        }

        public void Executer(IPersonnage user, IPersonnage target)
        {
            CapaciteDeBase.Executer(user, target);
        }
    }

    public class FireBall : ICapacity
    {
        public string CapacityName { get; set; } = "Boule de Feu";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int degatsMagiques = (int)(user.Stats.Magie * PowerUp);
                int resDamage = target.getDamage(degatsMagiques);
                Console.WriteLine($"{user.Name} lance {CapacityName} contre {target.Name} et lui inflige {resDamage} points de dégâts.");
                target.getLife();
            }
        }
    }

    public class Mercurocrom : ICapacity
    {
        public string CapacityName { get; set; } = "Mercurocrom";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int power = (int)(user.Stats.Wisom * PowerUp);
                target.setLife(power);
                Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et le soigne de {power} points de vie.");
                target.getLife();
            }
        }
    }


    public class DefenseBoost : ICapacity
    {
        public string CapacityName { get; set; } = "Barrière Magique";
        public double PowerUp { get; set; } = 1;


        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int boostDefense = (int)(user.Stats.Magie * PowerUp);
                Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et lui donne {boostDefense} points de défense supplémentaire.");
                target.setDefense(boostDefense);
            }
        }
    }


    public class CoupDeBouleMystiqueDuBlaireau : ICapacity
    {
        public string CapacityName { get; set; } = "Coup De Boule Mystique Du Blaireau";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int powerAttack = (int)((user.Stats.Power * 1.4) * PowerUp);
                int resDamage = target.getDamage(powerAttack);
                Console.WriteLine($"{user.Name} lance {CapacityName} contre {target.Name} et lui inflige {resDamage} points de dégâts.");
                target.getLife();
            }
        }
    }
    public class MagickBoost : ICapacity
    {
        public string CapacityName { get; set; } = "Boost de magie";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int boost = (int)((user.Stats.Magie * 1.3) * PowerUp);
                Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et lui donne {boost} points de magie supplémentaire.");
                target.setMagie(boost);
            }
        }
    }
    public class ChantEnroué : ICapacity
    {
        public string CapacityName { get; set; } = "Chant Enroué";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            if (!user.isDie() || !target.isDie())
            {
                int boost = (int)((user.Stats.Magie * 1.1) * PowerUp);
                Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et lui donne {boost} points de vie et de defense supplémentaire.");
                target.setDefense(boost);
                target.setLife(boost);
                target.setPower(boost);
            }
        }
    }

}