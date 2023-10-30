using System.Collections;
using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Items;
using Character.ItemManagement.Spawners;
using General;
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
        [SerializeField] private InventoryInteraction _inventoryInteraction;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private float _protectionDelay;

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
            _inventoryInteraction ??= GetComponent<InventoryInteraction>();
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

            if (EventHandler.IsInventoryInteract)
                StartCoroutine(DelayedSpawn(item, _protectionDelay));
            else SpawnItem(item);
        }

        private IEnumerator DelayedSpawn(Item item, float delay)
        {
            SetInteractableItems(false);

            yield return new WaitForSeconds(delay);

            SpawnItem(item);
            SetInteractableItems(true);
        }

        protected virtual void SpawnItem(Item item)
        {
            Spawn(item);
            Remove(item);
            StartTimer();
        }

        private void SetInteractableItems(bool value) => _inventoryInteraction.SetInteractableItems(value);

        protected void StartTimer() => _timer = new Timer(_spawnDelay, false);

        protected void Spawn(Item item) => _spawner.Spawn(item);

        protected void Remove(Item item)
        {
            _inventory.RemoveItem(item);
            _inventory.RefreshDisplay();
        }
    }
}