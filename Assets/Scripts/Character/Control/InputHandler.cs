using General;
using UnityEngine;

namespace Character.Control
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory _inventory;
        private void Update() => CheckKeys();

        private void CheckKeys()
        {
            if (Input.GetMouseButtonUp(0)) EventHandler.OnMouseButtonUp?.Invoke(0);
            if (Input.GetKeyUp(KeyCode.Tab) && _inventory != null)
            {
                _inventory.DisplayInventory();
                EventHandler.OnButtonUp?.Invoke(KeyCode.Tab);
            }
        }
    }
}