using UnityEngine;

namespace Character.Inventory.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;

        public ItemData GetData() => _itemData;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player") &&
                collision.transform.TryGetComponent(out Inventory inventory))
            {
                inventory.AddItem(this);
                gameObject.SetActive(false);
            }
        }
    }
}