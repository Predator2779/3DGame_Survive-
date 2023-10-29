using General;
using UnityEngine;

namespace Character.ItemManagement.InventoryManagement
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteraction : MonoBehaviour
    {
        [SerializeField] private Inventory _mainInventory;

        private Inventory _supportiveInventory;
        private InventoryBinder _invBinder;

        private void OnValidate() => _mainInventory ??= GetComponent<Inventory>();

        private void Start() => _mainInventory ??= GetComponent<Inventory>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out _supportiveInventory))
                DisplayEnable();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out _supportiveInventory))
                DisplayDisable();
        }

        private void DisplayEnable()
        {
            _invBinder = new InventoryBinder(_mainInventory, _supportiveInventory);
            _invBinder.DisplayInventories(true);

            EventHandler.OnInventoryButtonUp.AddListener(CheckDisplay);
        }

        private void CheckDisplay()
        {
            if (EventHandler.IsInventoryInteract) DisplayDisable();
        }

        private void DisplayDisable()
        {
            _invBinder = new InventoryBinder(_mainInventory, _supportiveInventory);
            _invBinder.DisplayInventories(false);
            _invBinder.Deinitialize();
            _invBinder = null;

            EventHandler.OnInventoryButtonUp.RemoveListener(CheckDisplay);
        }
    }
}