using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Items;
using Character.ItemManagement.Spawners;
using Other;
using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(ItemSpawner))]
    [RequireComponent(typeof(InventoryInteraction))]
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] protected Inventory _inventory;
        [SerializeField] private ItemSpawner _spawner;
        [SerializeField] private float _spawnDelay;

        private Timer _timer;

        protected void OnValidate() => SetNullableFields();

        protected void Start()
        {
            SetNullableFields();
            StartTimer();
        }

        protected virtual void SetNullableFields()
        {
            _inventory ??= GetComponent<Inventory>();
            _spawner ??= GetComponent<ItemSpawner>();
        }

        private void Update() => SpawnFromInventory();

        private void SpawnFromInventory()
        {
            if (_inventory.GetCount() != 0 &&
                _timer != null &&
                _timer.IsTimesUp())
                CheckInteract(_inventory.GetItem(0));
        }

        private void CheckInteract(Item item)
        {
            _timer = null;
            
            SpawnItem(item);
        }

        protected virtual void SpawnItem(Item item)
        {
            Spawn(item);
            Remove(item);
            StartTimer();
        }

        protected void StartTimer() => _timer = new Timer(_spawnDelay, false);

        protected void Spawn(Item item) => _spawner.Spawn(item);

        protected void Remove(Item item)
        {
            _inventory.RemoveItem(item);
            _inventory.RefreshDisplay();
        }
    }
}