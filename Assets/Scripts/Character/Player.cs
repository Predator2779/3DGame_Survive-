using Character.ItemManagement.Items;
using Character.ItemManagement.Items.UsableItems;
using General;
using UnityEngine;

namespace Character
{
    public class Player : Person
    {
        [SerializeField] private Transform _respawnPoint;
        
        protected override void Start()
        {
            base.Start();

            EventHandler.OnUsingItem.AddListener(UseItem);
        }

        private void UseItem(Item item, ItemManagement.InventoryManagement.Inventory inventory)
        {
            if (!item.Data.CanSelfUse() || inventory != GetInventory()) return;
            
            item.GetComponent<IUsable>().Use(this); // Try?
            inventory.RemoveItem(item);
            inventory.RefreshDisplay();
        }

        public override void Death()
        {
            new Transition().MoveObject(gameObject, _respawnPoint.position);
            
            GetHealth().TakeHealCompletely();
            GetCharacterNeeds().AddWater(100);
            GetCharacterNeeds().AddFood(100);
            GetCharacterMove().Move(transform.position);
        }
    }
}