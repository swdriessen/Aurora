namespace Aurora.Engine.Equipment.Interfaces
{
    public interface IEnhancementComponent
    {
        /// <summary>
        /// Gets the enhancement bonus name for this component.
        /// </summary>
        int GetEnhancementBonus();
    }

    public interface IEquipmentComponent : IEnhancementComponent
    {

    }
}