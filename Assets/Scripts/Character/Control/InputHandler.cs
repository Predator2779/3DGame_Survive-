using Character.Inventory;
using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.Control
{
    [RequireComponent(typeof(Person))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Person _person;
        [SerializeField] private Camera _cam;
        [SerializeField] private InventoryDrawer _invDrawer;

        private RaycastHit _hit;

        private void Start() => _person ??= GetComponent<Person>();

        private void Update()
        {
            SetRay();
            CheckKeys();
        }

        private void CheckKeys()
        {
            if (Input.GetMouseButtonUp(0)) MoveCharacter();

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                _invDrawer.DisplayInventory(_person);

                EventHandler.OnInventoryButtonUp?.Invoke();
            }
        }

        private void SetRay()
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) _hit = hit;
        }

        private void MoveCharacter() => _person.GetCharacterMove().Move(_hit.point);
    }
}