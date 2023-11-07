using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.ItemManagement.Items.UsableItems
{
    public class UsageIcon : MonoBehaviour
    {
        private Item _item;
        private InventoryManagement.Inventory _inventory;

        public void InitializeIcon(Item item, InventoryManagement.Inventory boundInv)
        {
            _item = item;
            _inventory = boundInv;
        }

        public void ClickButton()
        {
            if (EventHandler.IsInventoryInteract)
            {
                EventHandler.OnGivingItem?.Invoke(_item, _inventory);

                return;
            }

            if (_item.TryGetComponent(out UsableItem usable))
                EventHandler.OnUsingItem?.Invoke(usable, _inventory);
        }
    }
}