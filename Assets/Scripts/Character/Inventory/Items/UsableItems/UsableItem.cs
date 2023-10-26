namespace Character.Inventory.Items.UsableItems
{
    public abstract class UsableItem : Item, IUsable
    {
        public abstract void Use(Person person, float amount);
    }
}