namespace Character.Inventory.Items.UsableItems
{
    public class PoisonItem : UsableItem
    {
        public override void Use(Person person)
        {
            person.GetHealth().TakeDamage(ItemData.GetAmount());
        }
    }
}