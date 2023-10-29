using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.Inventory.Items.UsableItems
{
    public class UsageIcon : MonoBehaviour
    {
        private Item _item;
        
        public void SetItem(Item item) => _item = item;
        
        public void ClickButton()
        {
            if (EventHandler.IsInventoryInteract)
            {
                EventHandler.OnGivingItem?.Invoke();
                
                return;
            }
            
            EventHandler.OnUsingItem?.Invoke(_item);
        }
    }
}