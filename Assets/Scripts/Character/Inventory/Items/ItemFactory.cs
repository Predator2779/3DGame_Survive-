using UnityEngine;

namespace Character.Inventory.Items
{
    [RequireComponent(typeof(ItemSpawner)), RequireComponent(typeof(Inventory))]
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay;
        
        private ItemSpawner _spawner;
        private Inventory _inventory;
        private Timer _timer;

        private void Start()
        {
            _timer = new Timer(_spawnDelay, true);

            _spawner = GetComponent<ItemSpawner>();
            _inventory = GetComponent<Inventory>();
        }

        private void Update()
        {
            int length = _inventory.GetCount();

            if (length != 0) if (_timer != null && _timer.IsTimesUp()) Spawn(0);
        }

        private void Spawn(int index)
        {
            _spawner.SpawnItem(_inventory.GetItem(index));
            _inventory.RemoveItem(index);
        }
    }
}