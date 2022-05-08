using Aurora.Engine.Data.Interfaces;

namespace Aurora.Engine.Equipment
{
    public class EquipmentStore
    {
        private readonly IEquipmentDataProvider provider;

        public EquipmentStore(IEquipmentDataProvider provider)
        {
            this.provider = provider;
        }
    }
}