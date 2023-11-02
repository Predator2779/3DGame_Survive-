using Character.ItemManagement.Items;
using Character.ItemManagement.Items.UsableItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Character.ItemManagement.InventoryManagement
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
            button.image.sprite = item.Data.GetIcon();

            var usage = button.gameObject.AddComponent<UsageIcon>();
            usage.InitializeIcon(item, _inventory);

            button.transform.GetComponentInChildren<TMP_Text>().text = GetText(item);
            button.GetComponent<Button>().onClick.AddListener(usage.ClickButton);
        }

        private string GetText(Item item)
        {
            string text = item.Data.GetName();
            
            if (item.TryGetComponent(out UsableItem usable))
            {
                float amount = usable.UsableData.GetAmount();
                string amountText = $"{amount}";

                if (amount >= 0) amountText = $"+{amount}";

                text += " " + amountText;
            }

            return text;
        }

        public void Clear()
        {
            int childCount = _content.childCount;

            for (int i = 0; i < childCount; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}