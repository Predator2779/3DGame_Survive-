using UnityEngine;

namespace Character.Inventory.Factory
{
    [RequireComponent(typeof(ItemManagement.Inventory.Inventory))]
    public class MachineTool : MonoBehaviour
    {
        private ItemManagement.Inventory.Inventory _inventory;

        protected virtual void Start() => _inventory = GetComponent<ItemManagement.Inventory.Inventory>();

        public ItemManagement.Inventory.Inventory GetInventory() => _inventory;
    }
}