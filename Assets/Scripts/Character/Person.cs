using Character.Control;
using Character.Health;
using UnityEngine;

namespace Character
{
    public class Person : MonoBehaviour
    {
        [SerializeField] private CharacterMove _characterMove;
        [SerializeField] private CharacterNeeds _characterNeeds;
        [SerializeField] private HealthProcessor _health;
        [SerializeField] private Inventory.Inventory _inventory;
        
        public CharacterMove GetCharacterMove() => _characterMove;
        
        public CharacterNeeds GetCharacterNeeds() => _characterNeeds;
        
        public HealthProcessor GetHealth() => _health;
        
        public Inventory.Inventory GetInventory() => _inventory;
    }
}