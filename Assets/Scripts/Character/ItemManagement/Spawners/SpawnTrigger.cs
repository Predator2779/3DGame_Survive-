using UnityEngine;

namespace Character.ItemManagement.Spawners
{
    [RequireComponent(typeof(InventoryManagement.Inventory))]
    public class SpawnTrigger : ItemSpawner
    {
        private InventoryManagement.Inventory _inventory;

        private void Start() => _inventory = GetComponent<InventoryManagement.Inventory>();
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var item = _inventory.GetItem(0);
                
                Spawn(item);
                _inventory.RemoveItem(item);
            }
        }
    }
}