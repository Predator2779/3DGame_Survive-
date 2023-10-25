using Character.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Inventory
{
    public class InventoryDrawer : MonoBehaviour
    {
        [SerializeField] private RectTransform _inventoryPanel;
        [SerializeField] private RectTransform _content;

        private bool _isDisplayed;
    
        public void DisplayInventory(Item[] items)
        {
            if (_isDisplayed)
            {
                Clear();
            
                _isDisplayed = false;
                _inventoryPanel.gameObject.SetActive(false);
                return;
            }
        
            _inventoryPanel.gameObject.SetActive(true);

            var length = items.Length;

            for (int i = 0; i < length; i++)
            {
                var item = items[i];
                var icon = new GameObject("Icon");

                icon.AddComponent<Image>().sprite = item.ItemData.GetIcon();
                icon.transform.SetParent(_content);
            }

            _isDisplayed = true;
        }

        private void Clear()
        {
            var length = _content.childCount;

            for (int i = 0; i < length; i++)
                Destroy(_content.GetChild(i));
        }
    }
}