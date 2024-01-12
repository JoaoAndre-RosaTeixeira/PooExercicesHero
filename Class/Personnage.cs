using PooExercicesCS.Enum;
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
        public Etats Etats { get; set; }

        public Dictionary<Type, ICapacity> Capacities = new Dictionary<Type, ICapacity>();

        public Personnage(string name) 
        {   
            Name = name;
            Etats = Etats.Alive;
            PersonnageClass = new T();
            Stats = PersonnageClass.Stats;
            Stats.MaxLife = Stats.Life;
            Stats.MaxMana = Stats.Mana;
        }


        public virtual void attack(IPersonnage target)
        {
            if (Etats != Etats.Die) { 
                int powerDamage = Stats.Power;
                Console.WriteLine($"{Name} attaque {target.Name} et lui inflige {powerDamage} points de dégâts.");
                target.getDamage(powerDamage);
            }
        }

        public virtual int getDamage(int degats)
        {
            if (!isDie())
            {

                int degatsReduits = Math.Max(0, degats - Stats.Defense);
                
                Stats.Life = Math.Max(0, Stats.Life - degatsReduits);
                return degatsReduits;
            } else 
            {
                return 0;
            }
        }

        public bool isDie()
        { 
            if (Stats.Life <= 0) 
            { 
                Etats = Etats.Die;
                Console.WriteLine($"{Name} est mort.");
                return true;
            }
            else
            {
                return false;
            }        
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
            if (Stats.Life < Stats.MaxLife)
            {
                Stats.Life = Math.Min(Stats.MaxLife, Stats.Life + health);
            }
        }
        public void getLife()
        {
            Console.WriteLine($"{Name} a {Stats.Life} points de vie");
        }

        public void setPower(int boost)
        {
            Stats.Power += boost;
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
                Life = 35,
                Defense = 7,
                Power = 13,
                Magie = 1,
                Mana = 3,
                Wisom = 2
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
                Life = 20,
                Defense = 5,
                Power = 10,
                Magie = 13,
                Mana = 10,
                Wisom = 4
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
                Life = 25,
                Defense = 4,
                Power = 10,
                Magie = 6,
                Mana = 10,
                Wisom = 12
            };

        }
    }

    public class DemonLord : IClassPersonnage
    {
        public string ClassName { get; set; } = "Roi Démon";
        public Statistique Stats { get; set; }
        public DemonLord()
        {
            Stats = new()
            {
                Life = 80,
                Defense = 10,
                Power = 10,
                Magie = 10,
                Mana = 10,
                Wisom = 10
            };
        }

    }
    public class Bard : IClassPersonnage
    {
        public string ClassName { get; set; } = "Bard";
        public Statistique Stats { get; set; }
        public Bard()
        {
            Stats = new()
            {
                Life = 40,
                Defense = 7,
                Power = 7,
                Magie = 8,
                Mana = 10,
                Wisom = 8
            };
        }

    }
}
