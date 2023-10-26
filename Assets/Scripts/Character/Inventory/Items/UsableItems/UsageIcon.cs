using UnityEngine;

namespace Character.Inventory.Items.UsableItems
{
    public class UsageIcon : MonoBehaviour
    {
        private Item _item;

        public void SetItem(Item value) => _item = value;
        
        public void Use(Person person, float amount)
        {
            if (_item.ItemData.CanSelfUse()) _item.GetComponent<IUsable>().Use(person, amount);
        } 
    }
}