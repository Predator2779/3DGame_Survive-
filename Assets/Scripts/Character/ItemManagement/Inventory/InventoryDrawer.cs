using Character.Inventory.Items;
using Character.Inventory.Items.UsableItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Character.ItemManagement.Inventory
{
    public class InventoryDrawer : MonoBehaviour
    {
        [SerializeField] private RectTransform _inventoryPanel;
        [SerializeField] private RectTransform _content;
        [SerializeField] private Button _buttonPrefab;

        private Inventory _inventory;

        public void SetActive(Inventory inventory, bool value)
        {
            Clear();
            
            if (value) EnableDisplay(inventory);
            else DisableDisplay();
        }

        public void DrawItems()
        {
            var length = _inventory.GetCount();

            for (int i = 0; i < length; i++) CreateIcon(_inventory.GetItem(i));
        }

        public void EnableDisplay(Inventory inventory)
        {
            _inventory = inventory;
            _inventoryPanel.gameObject.SetActive(true);

            DrawItems();
        }

        public void DisableDisplay()
        {
            _inventory = null;
            _inventoryPanel.gameObject.SetActive(false);
        }

        private void CreateIcon(Item item)
        {
            var button = Instantiate(_buttonPrefab, _content);

            button.name = "Icon";
            button.image.sprite = item.ItemData.GetIcon();

            button.transform.GetComponentInChildren<TMP_Text>().text = GetText(item);

            var usage = button.gameObject.GetComponent<UsageIcon>();
            usage.SetItem(item);

            button.GetComponent<Button>().onClick.AddListener(usage.ClickButton);
        }

        private string GetText(Item item)
        {
            float amount = item.ItemData.GetAmount();
            string amountText = $"{amount}";

            if (amount >= 0) amountText = $"+{amount}";

            return $"{item.ItemData.GetName()} {amountText}";
        }

        private void Clear()
        {
            var length = _content.childCount;

            for (int i = 0; i < length; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}