namespace Character.ItemManagement.Items.UsableItems
{
    public class DrinkItem : UsableItem
    {
        public override void Use(Person person)
        {
            person.GetCharacterNeeds().AddWater(Data.GetAmount());
        }
    }
}