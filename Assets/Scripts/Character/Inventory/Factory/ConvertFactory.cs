using UnityEngine;

namespace Character.Inventory.Items.Factory
{
    [RequireComponent(typeof(ItemConverter))]
    public class ConvertFactory : ItemFactory
    {
        private ItemConverter _itemConverter;

        protected override void Start()
        {
            base.Start();

            _itemConverter = GetComponent<ItemConverter>();
        }

        protected override void SpawnAndRemove(Item item)
        {
            var newItem = _itemConverter.ConvertItem(item);
            
            Spawn(newItem);
            Remove(item);
        }
    }
}