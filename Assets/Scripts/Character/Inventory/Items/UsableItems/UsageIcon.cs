using UnityEngine;

namespace Character.Inventory.Items.UsableItems
{
    public class UsageIcon : MonoBehaviour
    {
        private Item _item;

        public void SetItem(Item item) => _item = item;
        
        public void Use(Person person)
        {
            if (_item.ItemData.CanSelfUse()) _item.GetComponent<IUsable>().Use(person);
            
            /// также удалить из InvDrawer
            
            person.GetInventory().RemoveItem(_item); /// удаление после использования
        } 
    }
}