namespace Character.Inventory.Items.UsableItems
{
    public interface IUsable
    {
        public void Use(Person person, float amount);
    }
}