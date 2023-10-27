using System;
using UnityEngine;

namespace Character.Inventory.Items.UsableItems
{
    [Serializable]
    public class UsageIcon : MonoBehaviour
    {
        [SerializeField] private Item _item;

        public void SetItem(Item item) => _item = item;
        
        public void Use(Person person)
        {
            if (_item.ItemData.CanSelfUse()) _item.GetComponent<IUsable>().Use(person);
            
            person.GetInventory().RemoveItem(_item);
        } 
    }
}