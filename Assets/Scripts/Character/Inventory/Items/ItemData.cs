using UnityEngine;

namespace Character.Inventory.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _gObject;

        public string GetName() => _name;
        public string GetDescription() => _description;
        public Sprite GetIcon() => _icon;
        public GameObject GetGameObject() => _gObject;
    }
}