using Character.ItemManagement.Items.Data;
using Character.ItemManagement.Items.UsableItems;
using UnityEngine;

namespace Character.ItemManagement.Items
{
    public abstract class UsableItem : Item, IUsable
    {
        [SerializeField] private UsableItemData _usableData;
        
        public UsableItemData UsableData => _usableData;

        public abstract void Use(Person person);
    }
}