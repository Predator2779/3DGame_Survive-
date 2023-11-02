using Character.ItemManagement.Items.Data;
using UnityEngine;

namespace Character.ItemManagement.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private ItemData _data;
        
        public ItemData Data 
        { 
            get => _data;
            set => _data = value;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player") &&
                collision.transform.TryGetComponent(out InventoryManagement.Inventory inventory))
            {
                inventory.AddItem(this);
                gameObject.SetActive(false);
            }
        }
    }
}