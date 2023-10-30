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

        private void Start() => _pathObjs ??= GameObject.Find("ITEMS").transform;

        public void Spawn(Item item)
        {
            _parent ??= Instantiate
            (
                    new GameObject(name: $"{name}_items"),
                    parent: _pathObjs
            ).transform;
            
            var clone = Instantiate
            (
                    item,
                    _spawnPosition.position,
                    Quaternion.identity,
                    _parent
            );
            
            clone.GetComponent<Item>().Data = item.Data;
        }
    }
}