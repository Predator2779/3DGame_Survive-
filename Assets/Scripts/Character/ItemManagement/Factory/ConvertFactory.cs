using Character.ItemManagement.Items;
using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(ItemConverter))]
    public class ConvertFactory : ItemFactory
    {
        private ItemConverter _itemConverter;

        protected override void SetNullableFields()
        {
            base.SetNullableFields();
            
            _itemConverter ??= GetComponent<ItemConverter>();
        }

        protected override void SpawnItem(Item item)
        {
            Spawn(_itemConverter.ConvertItem(item));
            Remove(item);
            StartTimer();
        }
    }
}