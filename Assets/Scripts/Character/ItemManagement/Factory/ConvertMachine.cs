using Character.ItemManagement.Items;
using UnityEngine;

namespace Character.ItemManagement.Factory
{
    [RequireComponent(typeof(ItemConverter))]
    public class ConvertMachine : MachineTool
    {
        private ItemConverter _itemConverter;

        protected override void SetNullableFields()
        {
            base.SetNullableFields();
            
            _itemConverter ??= GetComponent<ItemConverter>();
        }

        protected override void CreateItem(Item item)
        {
            Spawn(_itemConverter.ConvertItem(item));
            Remove(item);
            StartTimer();
        }
    }
}