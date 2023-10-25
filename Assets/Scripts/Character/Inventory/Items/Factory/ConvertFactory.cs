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

        protected override void Spawn(Item item)
        {
            item = _itemConverter.ConvertItem(item);
            
            base.Spawn(item);
        }
    }
}