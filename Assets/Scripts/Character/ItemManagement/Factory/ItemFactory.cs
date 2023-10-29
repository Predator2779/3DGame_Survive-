using Character.ItemManagement.Items;
using Character.ItemManagement.Spawners;
using Other;
using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(ItemSpawner))]
    public class ItemFactory : MachineTool
    {
        [SerializeField] private float _spawnDelay;

        private ItemSpawner _spawner;
        private Timer _timer;

        protected override void Start()
        {
            base.Start();
            
            _timer = new Timer(_spawnDelay, true);
            _spawner = GetComponent<ItemSpawner>();
        }

        protected virtual void Update() => SpawnFromInventory();

        private void SpawnFromInventory()
        {
            int length = GetInventory().GetCount();

            if (length != 0 &&
                _timer != null &&
                _timer.IsTimesUp())
                SpawnItem(GetInventory().GetItem(0));
        }

        protected virtual void SpawnItem(Item item)
        {
            Spawn(item);
            Remove(item);
            
            GetInventory().RefreshDisplay();
        }

        protected void Spawn(Item item) => _spawner.SpawnItem(item);

        protected void Remove(Item item) => GetInventory().RemoveItem(item);
    }
}