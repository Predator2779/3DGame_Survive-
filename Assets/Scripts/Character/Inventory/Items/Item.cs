using UnityEngine;

namespace Character.Inventory.Items
{
    public class Item : MonoBehaviour
    {
        public ItemData ItemData { get; set; }
        
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