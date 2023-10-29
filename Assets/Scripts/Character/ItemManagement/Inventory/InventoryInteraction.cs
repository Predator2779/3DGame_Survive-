using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.ItemManagement.Inventory
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteraction : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        private Inventory _supportiveInventory;

        private void Start() => _inventory = GetComponent<Inventory>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Inventory supportiveInventory))
                DisplayInventories(supportiveInventory, true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Inventory supportiveInventory))
            {
                DisplayInventories(supportiveInventory, true);

                _supportiveInventory = null;
            }
        }

        private void DisplayInventories(Inventory supportiveInventory, bool displayActive)
        {
            _supportiveInventory = supportiveInventory;

            _inventory.Displaying(displayActive);
            _supportiveInventory.Displaying(displayActive);

            EventHandler.IsInventoryInteract = displayActive;
        }
    }
}