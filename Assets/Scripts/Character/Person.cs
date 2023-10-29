using Character.Control;
using Character.Health;
using General;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterMove))]
    [RequireComponent(typeof(CharacterNeeds))]
    [RequireComponent(typeof(HealthProcessor))]
    [RequireComponent(typeof(ItemManagement.InventoryManagement.Inventory))]
    public abstract class Person : MonoBehaviour
    {
        [SerializeField] private CharacterMove _characterMove;
        [SerializeField] private CharacterNeeds _characterNeeds;
        [SerializeField] private HealthProcessor _health;
        [SerializeField] private ItemManagement.InventoryManagement.Inventory _inventory;
        
        private void OnValidate() => SetNullableFields();

        protected virtual void Start() => SetNullableFields();
        
        private void SetNullableFields()
        {
            _characterMove ??= GetComponent<CharacterMove>();
            _characterNeeds ??= GetComponent<CharacterNeeds>();
            _health ??= GetComponent<HealthProcessor>();
            _inventory ??= GetComponent<ItemManagement.InventoryManagement.Inventory>();
        }

        public CharacterMove GetCharacterMove() => _characterMove;

        public CharacterNeeds GetCharacterNeeds() => _characterNeeds;

        public HealthProcessor GetHealth() => _health;

        public ItemManagement.InventoryManagement.Inventory GetInventory() => _inventory;

        public abstract void Death();
    }
}