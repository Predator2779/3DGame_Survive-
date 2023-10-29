namespace Character.Inventory.Items.UsableItems
{
    public class FoodItem : UsableItem
    {
        public override void Use(Person person)
        {
            person.GetCharacterNeeds().AddFood(ItemData.GetAmount());
        }
    }
}