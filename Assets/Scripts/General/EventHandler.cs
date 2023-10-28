using Character.Inventory.Items;
using UnityEngine.Events;

namespace General
{
    public static class EventHandler
    {
        public static bool IsInventoryInteract { get; set; }

        public static UnityEvent<Item> OnUsingItem = new();
        public static UnityEvent OnGivingItem = new();
    }
}