using PooExercicesCS.Interface;

namespace PooExercicesCS.Class
{

    public class Maxi<T> : ICapacity where T : ICapacity, new()
    {
        public T CapaciteDeBase { get; set; } = new T();
        public string CapacityName { get; set; } = "Maxi ";
        public double PowerUp { get; set; } = 2;

        public Maxi() 
        {
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
            int degatsMagiques = (int)(user.Stats.Magie * PowerUp);
            int resDamage = target.getDamage(degatsMagiques);
            Console.WriteLine($"{user.Name} lance {CapacityName} contre {target.Name} et lui inflige {resDamage} points de dégâts.");
            target.getLife();
        }
    }


    public class DefenseBoost : ICapacity
    {
        public string CapacityName { get; set; } = "Barrière Magique";
        public double PowerUp { get; set; } = 1;


        public void Executer(IPersonnage user, IPersonnage target)
        {
            int boostDefense = (int)(user.Stats.Magie + user.Stats.Defense * PowerUp);
            Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et lui donne {boostDefense} points de défense supplémentaire.");
            target.setDefense(boostDefense);
        }
    }


    public class CoupDeBouleMystiqueDuBlaireau : ICapacity
    {
        public string CapacityName { get; set; } = "Coup De Boule Mystique Du Blaireau";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            int powerAttack = (int)((user.Stats.Force * 1.4) * PowerUp);
            int resDamage = target.getDamage(powerAttack);
            Console.WriteLine($"{user.Name} lance {CapacityName} contre {target.Name} et lui inflige {resDamage} points de dégâts.");
            target.getLife();
        }
    }
    public class MagickBoost : ICapacity
    {
        public string CapacityName { get; set; } = "Boost de magie";
        public double PowerUp { get; set; } = 1;

        public void Executer(IPersonnage user, IPersonnage target)
        {
            int boost = (int)((user.Stats.Magie * 1.5) * PowerUp);
            Console.WriteLine($"{user.Name} lance {CapacityName} sur {target.Name} et lui donne {boost} points de magie supplémentaire.");
            target.setMagie(boost);
        }
    }
    
}
