using PooExercicesCS.Class;

namespace PooExercicesCS.Interface
{
    public interface ICapacity
    {
        string CapacityName { get; set; }
        double PowerUp { get; set; }

        void Executer(IPersonnage user, IPersonnage target );
    }
}