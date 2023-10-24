using UnityEngine;

namespace Character.Inventory.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        
        public void SpawnItem(Item item)
        {
            var data = item.ItemData;
            var clone = Instantiate
            (
                    item,
                    _spawnPosition.position,
                    Quaternion.identity
            );
            
            clone.GetComponent<Item>().ItemData = data;
        }
    }
}