using Character.ItemManagement.Items;
using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(ItemConverter))]
    public class ConvertFactory : ItemFactory
    {
        private ItemConverter _itemConverter;

        private void OnValidate() => _itemConverter ??= GetComponent<ItemConverter>();

        protected override void Start()
        {
            base.Start();

            _itemConverter ??= GetComponent<ItemConverter>();
        }

        protected override void SpawnItem(Item item)
        {
            var newItem = _itemConverter.ConvertItem(item);
            
            Spawn(newItem);
            Remove(item);
            
            GetInventory().RefreshDisplay();
        }
    }
}