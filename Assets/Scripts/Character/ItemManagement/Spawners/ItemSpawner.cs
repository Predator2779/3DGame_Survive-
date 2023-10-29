using Character.ItemManagement.Items;
using UnityEngine;

namespace Character.ItemManagement.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        private Transform _pathObjs;
        private Transform _parent;
        
        private void OnValidate() => _pathObjs ??= GameObject.Find("ITEMS").transform;

        public void SpawnItem(Item item)
        {
            var data = item.Data;
            
            var clone = Instantiate
            (
                    item,
                    _spawnPosition.position,
                    Quaternion.identity
            );

            _parent ??= Instantiate
            (
                    new GameObject(name: $"{name}_items"),
                    parent: _pathObjs
            ).transform;

            clone.transform.SetParent(_parent);
            clone.GetComponent<Item>().Data = data;
        }
    }
}