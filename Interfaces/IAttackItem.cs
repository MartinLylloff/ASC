namespace MandatoryAssignmentLibrary.Interfaces
{
    public interface IAttackItem : IItem
    {
        int Damage { get; set; }
        int Range { get; set; }
        void Buff();
    }
}