using UnityEngine;

namespace Character.Inventory.Items.Factory
{
    public class ItemConverter : MonoBehaviour
    {
        [SerializeField] private Item _inputItem;
        [SerializeField] private Item _outputItem;

        public Item ConvertItem(Item inputItem)
        {
            if (inputItem == _inputItem) return _outputItem;

            return inputItem;
        }
    }
}