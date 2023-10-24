using System.Collections.Generic;
using Character.Inventory.Items;
using UnityEngine;

namespace Character.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryDrawer _invDrawer;
        [SerializeField, Min(1)] private int _size;
        [SerializeField] private List<Item> _items = new();

        public void AddItem(Item item)
        {
            if (!_items.Contains(item) && _items.Count < _size) _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }

        public void RemoveItem(int index)
        {
            if (_items.Contains(_items[index])) _items.Remove(_items[index]);
        }

        public Item GetItem(int index) => _items[index];

        public int GetCount() => _items.Count;
        
        public void DisplayInventory() => _invDrawer.DisplayInventory(_items.ToArray());
    }
}