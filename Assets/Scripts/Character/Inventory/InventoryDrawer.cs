using Character.Inventory.Items;
using Character.Inventory.Items.UsableItems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Inventory
{
    public class InventoryDrawer : MonoBehaviour
    {
        [SerializeField] private RectTransform _inventoryPanel;
        [SerializeField] private RectTransform _content;
        [SerializeField] private Button _buttonPrefab;

        private Person _person;
        private Inventory _inventory;
        private UsageIcon _usage;
        private bool _isDisplayed;

        public void DisplayInventory(Person person) //// переделать передачу person и inventory
        {
            SwitchDisplay();
            
            _person = person;
            _inventory = person.GetInventory();
            _inventoryPanel.gameObject.SetActive(_isDisplayed);
            
            Draw();
        }

        private void Draw()
        {
            Clear();

            if (_isDisplayed)
            {
                CreateItems(); return;
            }
            
            Nullify();
        }

        private bool SwitchDisplay()
        {
            if (_isDisplayed) _isDisplayed = false;
            else _isDisplayed = true;

            return _isDisplayed;
        }

        private void CreateItems()
        {
            var length = _inventory.GetCount();

            for (int i = 0; i < length; i++) CreateIcon(_inventory.GetItem(i));
        }

        private void CreateIcon(Item item)
        {
            var button = Instantiate(_buttonPrefab, _content);

            button.name = "Icon";
            button.image.sprite = item.ItemData.GetIcon();

            button.transform.GetComponentInChildren<TMP_Text>().text = GetText(item);

            _usage = button.gameObject.AddComponent<UsageIcon>();
            _usage.SetItem(item);

            button.GetComponent<Button>().onClick.AddListener(Use);
        }

        private string GetText(Item item)
        {
            float amount = item.ItemData.GetAmount();
            string amountText = $"{amount}";

            if (amount >= 0) amountText = $"+{amount}";

            return $"{item.ItemData.GetName()} {amountText}";
        }

        private void Use()
        {
            _usage.Use(_person);
            
            Draw();
        }

        private void Clear()
        {
            var length = _content.childCount;

            for (int i = 0; i < length; i++)
                Destroy(_content.GetChild(i).gameObject);
        }

        private void Nullify()
        {
            _person = null;
            _inventory = null;
            _usage = null;
        }
    }
}