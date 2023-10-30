using Character.ItemManagement.Items;
using General;

namespace Character.ItemManagement.InventoryManagement
{
    public class InventoryBinder
    {
        public InventoryBinder(Inventory mainInv, Inventory supportInv)
        {
            _mainInventory = mainInv;
            _supportiveInventory = supportInv;

            Initialize();
        }

        private readonly Inventory _mainInventory;
        private readonly Inventory _supportiveInventory;

        private void Initialize() => EventHandler.OnGivingItem.AddListener(GiveItem);

        public void DisplayInventories(bool displayActive)
        {
            _mainInventory.Displaying(displayActive);
            _supportiveInventory.Displaying(displayActive);

            EventHandler.IsInventoryInteract = displayActive;
        }

        private void GiveItem(Item item, Inventory inventory)
        {
            if (inventory == _mainInventory)
            {
                Exchange(_mainInventory, _supportiveInventory, item);
                
                return;
            }

            if (inventory == _supportiveInventory) Exchange(_supportiveInventory, _mainInventory, item);
        }

        private void Exchange(Inventory fromInv, Inventory toInv, Item item)
        {
            toInv.AddItem(item);
            fromInv.RemoveItem(item);

            toInv.RefreshDisplay();
            fromInv.RefreshDisplay();
        }

        public void Deinitialize() => EventHandler.OnGivingItem.RemoveListener(GiveItem);
    }
}