using UnityEngine;

namespace Character.ItemManagement.Items
{
    public class ItemConverter : MonoBehaviour
    {
        [SerializeField] private Item _inputItem;
        [SerializeField] private Item _outputItem;

        public Item ConvertItem(Item inputItem) => inputItem == _inputItem ? _outputItem : inputItem;
    }
}