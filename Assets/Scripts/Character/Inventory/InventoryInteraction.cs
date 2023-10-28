using System;
using UnityEngine;
using EventHandler = General.EventHandler;

namespace Character.Inventory
{
    [RequireComponent(typeof(Inventory))]
    public class InventoryInteraction : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        private void Start() => _inventory = GetComponent<Inventory>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Inventory secondInventory))
            {
                _inventory.Displaying(true);
                secondInventory.Displaying(true);

                EventHandler.IsInventoryInteract = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Inventory secondInventory))
            {
                _inventory.Displaying(false);
                secondInventory.Displaying(false);
                
                EventHandler.IsInventoryInteract = false;
            }
        }
    }
}