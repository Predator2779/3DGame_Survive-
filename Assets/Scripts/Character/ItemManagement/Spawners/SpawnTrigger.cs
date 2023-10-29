using UnityEngine;

namespace Character.Inventory.Spawners
{
    [RequireComponent(typeof(ItemManagement.Inventory.Inventory))]
    public class SpawnTrigger : ItemSpawner
    {
        private ItemManagement.Inventory.Inventory _inventory;

        private void Start() => _inventory = GetComponent<ItemManagement.Inventory.Inventory>();
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