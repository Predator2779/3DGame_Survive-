using System.Collections.Generic;
using Character.Inventory.Items;
using UnityEngine;

namespace Character.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> _items = new();
        [SerializeField] private InventoryDrawer _invDrawer;

        public void AddItem(Item item)
        {
            if (!_items.Contains(item)) _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }

        public void DisplayInventory() => _invDrawer.DisplayInventory(_items.ToArray());
    }
}