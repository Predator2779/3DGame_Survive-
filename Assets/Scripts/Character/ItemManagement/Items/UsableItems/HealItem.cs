namespace Character.ItemManagement.Items.UsableItems
{
    public class HealItem : UsableItem
    {
        public override void Use(Person person)
        {
            person.GetHealth().TakeHeal(Data.GetAmount());
        }
    }
}