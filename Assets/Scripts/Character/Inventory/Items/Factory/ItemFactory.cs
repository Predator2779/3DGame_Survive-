using Other;
using UnityEngine;

namespace Character.Inventory.Items.Factory
{
    [RequireComponent(typeof(ItemSpawner)), RequireComponent(typeof(Inventory))]
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay;

        private ItemSpawner _spawner;
        private Inventory _inventory;
        private Timer _timer;

        protected virtual void Start()
        {
            _timer = new Timer(_spawnDelay, true);

            _spawner = GetComponent<ItemSpawner>();
            _inventory = GetComponent<Inventory>();
        }

        protected virtual void Update() => SpawnFromInventory();

        private void SpawnFromInventory()
        {
            int length = _inventory.GetCount();

            if (length != 0 &&
                _timer != null &&
                _timer.IsTimesUp())
                SpawnAndRemove(_inventory.GetItem(0));
        }

        protected virtual void SpawnAndRemove(Item item)
        {
            Spawn(item);
            Remove(item);
        }

        protected void Spawn(Item item) => _spawner.SpawnItem(item);

        protected void Remove(Item item) => _inventory.RemoveItem(item);
    }
}