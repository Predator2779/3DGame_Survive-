using UnityEngine;

namespace Character.ItemManagement.Items.Data
{
    [CreateAssetMenu(fileName = "New UsableItem", menuName = "Items/UsableItem", order = 0)]
    public class UsableItemData : ItemData
    {
        [SerializeField] private float _amount;
        
        public float GetAmount() => _amount;
    }
}