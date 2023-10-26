namespace Character.Inventory.Items.UsableItems
{
    public class PoisonItem : UsableItem
    {
        public override void Use(Person person, float amount)
        {
            person.GetHealth().TakeDamage(amount);
        }
    }
}