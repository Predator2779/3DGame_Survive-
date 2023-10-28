using Character.Inventory;
using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.Control
{
    [RequireComponent(typeof(Person))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Person _person;
        [SerializeField] private InventoryDrawer _invDrawer;

        private void OnValidate() => _person ??= GetComponent<Person>();

        private void Update() => CheckKeys();

        private void CheckKeys()
        {
            if (Input.GetMouseButtonUp(0)) _person.GetCharacterMove().Move();
            
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                _invDrawer.DisplayInventory(_person);
                
                EventHandler.OnInventoryButtonUp?.Invoke();
            }
        }
    }
}