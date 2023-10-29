using Character.ItemManagement.Spawners;
using UnityEngine;

namespace Character.Inventory.Spawners
{
    [RequireComponent(typeof(ItemManagement.InventoryManagement.Inventory))]
    public class SpawnTrigger : ItemSpawner
    {
        private ItemManagement.InventoryManagement.Inventory _inventory;

        private void Start() => _inventory = GetComponent<ItemManagement.InventoryManagement.Inventory>();
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var item = _inventory.GetItem(0);
                
                SpawnItem(item);
                
                _inventory.RemoveItem(item);
            }
        }
    }
}