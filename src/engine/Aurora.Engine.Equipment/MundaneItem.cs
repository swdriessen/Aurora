namespace Aurora.Engine.Equipment
{
    public class MundaneItem : InventoryItem
    {
        public MundaneItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string GetDisplayName()
        {
            return Name;
        }
    }
}