using UnityEngine;

namespace Character.ItemManagement.InventoryManagement
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteraction : MonoBehaviour
    {
        [SerializeField] private Inventory _mainInventory;

        private InventoryBinder _invBinder;

        private void OnValidate() => _mainInventory ??= GetComponent<Inventory>();

        private void Start() => _mainInventory ??= GetComponent<Inventory>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Inventory supportiveInventory))
            {
                _invBinder = new InventoryBinder(_mainInventory, supportiveInventory);
                _invBinder.DisplayInventories(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Inventory supportiveInventory))
            {
                _invBinder = new InventoryBinder(_mainInventory, supportiveInventory);
                _invBinder.DisplayInventories(false);
                _invBinder.Deinitialize();
                _invBinder = null;
            }
        }
    }
}