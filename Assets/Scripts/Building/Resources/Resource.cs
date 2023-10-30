using Character.ItemManagement.Items;
using UnityEngine;

namespace Building.Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Item _resource;
        [SerializeField] private int _count;
        
        public ItemData GetData() => _resource.Data;
        public int GetCount() => _count;
    }
}