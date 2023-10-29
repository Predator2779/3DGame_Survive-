using Character.ItemManagement.Items;
using Character.ItemManagement.Items.UsableItems;
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

        private void UseItem(Item item, ItemManagement.InventoryManagement.Inventory inventory)
        {
            if (!item.Data.CanSelfUse() || inventory != GetInventory()) return;
            
            item.GetComponent<IUsable>().Use(this); // Try?
            inventory.RemoveItem(item);
            inventory.RefreshDisplay();
        }
    }
}