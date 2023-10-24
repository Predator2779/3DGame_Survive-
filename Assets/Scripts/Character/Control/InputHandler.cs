using UnityEngine;

namespace Character
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory _inventory;
        
        private void Update() => CheckKeys();

        private void CheckKeys()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
                _inventory.DisplayInventory();
        }
    }
}