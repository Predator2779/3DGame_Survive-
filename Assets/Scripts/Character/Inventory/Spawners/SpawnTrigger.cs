using UnityEngine;

namespace Character.Inventory.Spawners
{
    [RequireComponent(typeof(Inventory))]
    public class SpawnTrigger : ItemSpawner
    {
        private Inventory _inventory;

        private void Start() => _inventory = GetComponent<Inventory>();
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