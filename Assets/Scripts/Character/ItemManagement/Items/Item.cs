using UnityEngine;

namespace Character.ItemManagement.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private ItemData data;
        
        public ItemData Data 
        { 
            get => data;
            set => data = value;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player") &&
                collision.transform.TryGetComponent(out ItemManagement.InventoryManagement.Inventory inventory))
            {
                inventory.AddItem(this);
                gameObject.SetActive(false);
            }
        }
    }
}