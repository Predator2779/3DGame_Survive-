namespace Character.ItemManagement.Items.UsableItems
{
    public class FoodItem : UsableItem
    {
        public override void Use(Person person)
        {
            person.GetCharacterNeeds().AddFood(UsableData.GetAmount());
        }
    }
}