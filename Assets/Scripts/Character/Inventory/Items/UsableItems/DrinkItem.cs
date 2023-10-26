namespace Character.Inventory.Items.UsableItems
{
    public class DrinkItem : UsableItem
    {
        public override void Use(Person person, float amount)
        {
            person.GetCharacterNeeds().AddWater(amount);
        }
    }
}