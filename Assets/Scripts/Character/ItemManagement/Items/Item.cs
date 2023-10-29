using UnityEngine;

namespace Character.Inventory.Items
{
    public class Item : MonoBehaviour /// abstract?
    {
        [SerializeField] private ItemData _itemData;
        
        public ItemData ItemData 
        { 
            get => _itemData;
            set => _itemData = value;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player") &&
                collision.transform.TryGetComponent(out ItemManagement.Inventory.Inventory inventory))
            {
                inventory.AddItem(this);
                gameObject.SetActive(false);
            }
        }
    }
}