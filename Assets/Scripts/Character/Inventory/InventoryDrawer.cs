using Character.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDrawer : MonoBehaviour
{
    [SerializeField] private RectTransform _inventoryPanel;

    private bool _isDisplayed;

    public void DisplayInventory(Item[] items)
    {
        if (_isDisplayed)
        {
            ClearInventory();
            
            _isDisplayed = false;
            _inventoryPanel.gameObject.SetActive(false);
            
            return;
        }

        _isDisplayed = true;
        _inventoryPanel.gameObject.SetActive(true);
        
        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            var icon = new GameObject("Icon");

            icon.AddComponent<Image>().sprite = item.GetData().GetIcon();
            icon.transform.SetParent(_inventoryPanel);
        }
    }

    private void ClearInventory()
    {
        int length = _inventoryPanel.childCount;

        for (int i = 0; i < length; i++) Destroy(_inventoryPanel.GetChild(i).gameObject);
    }
}