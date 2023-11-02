using System.Collections.Generic;
using Character.ItemManagement.Items;
using UnityEngine;

namespace Character.ItemManagement.InventoryManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryDrawer _inventoryDrawer;
        [SerializeField, Min(1)] private int _size;
        [SerializeField] private List<Item> _items = new();

        public bool IsDisplayed { get; private set; }

        private void OnValidate() => SetDrawer();

        private void Start() => SetDrawer();
        
        private void SetDrawer() => _inventoryDrawer ??= GameObject.Find("SupportiveWindow").GetComponent<InventoryDrawer>();

        public void AddItem(Item item)
        {
            if (!Contains(item) && GetCount() < _size) _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (Contains(item)) _items.Remove(item);
        }

        public bool Contains(Item item) => _items.Contains(item);
        
        public Item GetItem(int index) => _items[index];

        public int GetCount() => _items.Count;
        
        public void RefreshDisplay()
        {
            if (!IsDisplayed) return;

            _inventoryDrawer.Clear();
            _inventoryDrawer.DrawItems();
        }

        public InventoryDrawer GetDrawer() => _inventoryDrawer;
        
        public void SwitchDisplay()
        {
            IsDisplayed = !IsDisplayed;
        
            Displaying(IsDisplayed);
        }
        
        public void Displaying(bool value)
        {
            _inventoryDrawer.SetActive(this, value);
            
            IsDisplayed = value;
        }
    }
}