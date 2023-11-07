using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Items;
using UnityEngine.Events;

namespace General
{
    public static class EventHandler
    {
        public static bool IsInventoryInteract { get; set; }

        public static readonly UnityEvent OnInventoryButtonUp = new();
        public static readonly UnityEvent<Item, Inventory> OnUsingItem = new();
        public static readonly UnityEvent<Item, Inventory> OnGivingItem = new();
    }
}