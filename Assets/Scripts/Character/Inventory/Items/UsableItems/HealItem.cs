namespace Character.Inventory.Items.UsableItems
{
    public class HealItem : UsableItem
    {
        public override void Use(Person person, float amount)
        {
            person.GetHealth().TakeHeal(amount);
        }
    }
}