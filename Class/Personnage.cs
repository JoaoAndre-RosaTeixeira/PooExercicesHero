using PooExercicesCS.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PooExercicesCS.Class
{
    public class Personnage<T> : IPersonnage where T : IClassPersonnage, new()
    {
        public string Name { get; set; }
        public Statistique Stats { get; private set; }
        public IClassPersonnage PersonnageClass { get; set; }

        public Dictionary<Type, ICapacity> Capacities = new Dictionary<Type, ICapacity>();

        public Personnage(string name) 
        {   
            Name = name;
            PersonnageClass = new T();
            Stats = PersonnageClass.Stats;
        }


        public virtual void attack(IPersonnage target)
        {
            int powerDamage = Stats.Force;
            Console.WriteLine($"{Name} attaque {target.Name} et lui inflige {powerDamage} points de dégâts.");
            target.getDamage(powerDamage);
        }

        public virtual int getDamage(int degats)
        {
            int degatsReduits = Math.Max(0, degats - Stats.Defense);
            Stats.Life -= degatsReduits;
            return degatsReduits;
        }

        public void AddCapacity(ICapacity capacity)
        {
            Capacities[capacity.GetType()] = capacity;
        }
        public void UseCapacity<T>(IPersonnage target) where T : class, ICapacity
        {
            if (Capacities.TryGetValue(typeof(T), out ICapacity capacity))
            {
                capacity.Executer(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} n'a pas la capacité {typeof(T).Name}.");
            }
        }

        public void setDefense(int boostDefense)
        {
            Stats.Defense += boostDefense;
        }

        public void setMagie(int boost)
        {
            Stats.Magie += boost;
        }

        public void setLife(int health)
        {
            Stats.Life += health;
        }
        public void getLife()
        {
            Console.WriteLine($"{Name} n'as plus que {Stats.Life} points de vie");
        }

        
    }


    public class Warrior : IClassPersonnage
    {
        public string ClassName { get; set; } = "Warrior";
        public Statistique Stats { get; set; }
        public Warrior()
        {
            Stats = new()
            {
                Life = 20,
                Defense = 7,
                Force = 10,
                Magie = 1
            };

        }
    }
    public class Wizard : IClassPersonnage
    {
        public string ClassName { get; set; } = "Wizard";
        public Statistique Stats { get; set; }
        public Wizard()
        {
            Stats = new()
            {
                Life = 15,
                Defense = 5,
                Force = 10,
                Magie = 13
            };

        }
    }
    public class Cleric : IClassPersonnage
    {
        public string ClassName { get; set; } = "Cleric";
        public Statistique Stats { get; set; }
        public Cleric()
        {
            Stats = new()
            {
                Life = 20,
                Defense = 4,
                Force = 10,
                Magie = 8
            };

        }
    }
}
