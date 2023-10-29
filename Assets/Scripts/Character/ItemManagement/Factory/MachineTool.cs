using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(ItemManagement.InventoryManagement.Inventory))]
    public class MachineTool : MonoBehaviour
    {
        private ItemManagement.InventoryManagement.Inventory _inventory;

        protected virtual void Start() => _inventory = GetComponent<ItemManagement.InventoryManagement.Inventory>();

        public ItemManagement.InventoryManagement.Inventory GetInventory() => _inventory;
    }
}