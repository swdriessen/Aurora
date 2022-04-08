namespace Aurora.Engine.Equipment
{
    public class EquipmentManager
    {
        public EquipmentManager() 
        {

        }

        public InventoryItemCollection Items { get; } = new();
    }
}