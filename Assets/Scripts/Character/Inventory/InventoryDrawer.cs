using Character.Inventory.Items;
using Character.Inventory.Items.UsableItems;
using Unity.VisualScripting;
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
            _inventoryPanel.gameObject.SetActive(SwitchDisplay());

            Clear();

            if (_isDisplayed) CreateItems(items);
        }

        private bool SwitchDisplay()
        {
            if (_isDisplayed) _isDisplayed = false;
            else _isDisplayed = true;

            return _isDisplayed;
        }

        private void CreateItems(Item[] items)
        {
            var length = items.Length;

            for (int i = 0; i < length; i++)
            {
                var item = items[i];
                var icon = new GameObject("Icon");

                icon.transform.SetParent(_content);
                
                var button = icon.AddComponent<Button>();
                button.image.sprite = item.ItemData.GetIcon();
                button.GetComponent<Button>().onClick.AddListener(Ahah);
                        
                // icon.AddComponent<Image>().sprite = item.ItemData.GetIcon();
                icon.AddComponent<UsageIcon>().SetItem(item);
            }
        }

        private void Ahah()
        {
            print("ahahahah");
        }

        private void Clear()
        {
            var length = _content.childCount;

            for (int i = 0; i < length; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}