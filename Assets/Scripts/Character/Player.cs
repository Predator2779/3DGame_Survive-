using Character.Inventory.Items;
using Character.Inventory.Items.UsableItems;
using General;

namespace Character
{
    public class Player : Person
    {
        protected override void Start()
        {
            base.Start();
            
            EventHandler.OnUsingItem.AddListener(UseItem);
        }

        private void UseItem(Item item)
        {
            item.GetComponent<IUsable>().Use(this); // Try?
            
            var inventory = GetInventory();
            
            inventory.RemoveItem(item); // чей инвентарь используется во время исп предмета?
            inventory.GetDrawer().DrawItems();
        }
    }
}