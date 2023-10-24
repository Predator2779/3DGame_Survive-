using Character.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDrawer : MonoBehaviour
{
    [SerializeField] private RectTransform _inventoryPanel;
    [SerializeField] private RectTransform _content;
    
    public void DisplayInventory(Item[] items)
    {
        _inventoryPanel.gameObject.SetActive(true);
        
        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            var icon = new GameObject("Icon");
            
            icon.AddComponent<Image>().sprite = item.ItemData.GetIcon();
            icon.transform.SetParent(_content);
        }
    }
}