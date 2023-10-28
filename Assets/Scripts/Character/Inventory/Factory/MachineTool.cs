using UnityEngine;

namespace Character.Inventory.Factory
{
    [RequireComponent(typeof(Inventory))]
    public class MachineTool : MonoBehaviour
    {
        private Inventory _inventory;

        protected virtual void Start() => _inventory = GetComponent<Inventory>();

        public Inventory GetInventory() => _inventory;
    }
}