using UnityEngine;
using UnityEngine.Events;

namespace General
{
    public static class EventHandler
    {
        public static UnityEvent<int> OnMouseButtonUp = new();
        public static UnityEvent<KeyCode> OnButtonUp = new();
    }
}