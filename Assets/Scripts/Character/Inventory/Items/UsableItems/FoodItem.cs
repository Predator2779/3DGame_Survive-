namespace Character.Inventory.Items.UsableItems
{
    public class FoodItem : UsableItem
    {
        public override void Use(Person person, float amount)
        {
            person.GetCharacterNeeds().AddFood(amount);
        }
    }
}