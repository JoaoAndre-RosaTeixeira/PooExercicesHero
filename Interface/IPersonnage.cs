using PooExercicesCS.Class;
using System.Collections.Generic;

namespace PooExercicesCS.Interface
{
    public interface IPersonnage
    {
        string Name { get; set; }
        Statistique Stats { get; }
        IClassPersonnage PersonnageClass { get; set; }
        void AddCapacity(ICapacity capacity);
        void UseCapacity<T>(IPersonnage target) where T : class, ICapacity;
        void attack(IPersonnage target);
        int getDamage(int damage);
        void setDefense(int boostDefense);
        void setMagie(int boost);
        void setLife(int health);
        void getLife();
       
    }
}
