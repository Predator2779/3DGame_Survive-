using System.Collections.Generic;
using Building.Resources;
using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Items;
using Character.ItemManagement.Spawners;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Building
{
    [RequireComponent(typeof(ItemSpawner))]
    public class BuildManager : MonoBehaviour
    {
        [SerializeField] private Construction _construction;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Transform _place;

        private List<Item> _resources;

        private void Start()
        {
            TryBuildConstruction(_construction, _inventory);
        }

        public void TryBuildConstruction(Construction construction, Inventory inventory)
        {
            var requirements = construction.GetRequirements();

            if (!GetResources(ref _resources, requirements)) return;

            var builder = new Builder(construction, _resources);

            if (builder.CanBuild()) builder.Build(GetPosition(_place), _place.rotation);
            else builder.ReturnResources(this);
        }

        private Vector3 GetPosition(Transform t) => new(t.position.x, t.position.y, t.position.z);

        private bool GetResources(
                ref List<Item> resources,
                List<ResourceDescription> requirements)
        {
            resources = null;
            
            int length = requirements.Count;
            for (int i = 0; i < length; i++)
            {
                int jLength = _inventory.GetCount();
                for (int j = 0; j < jLength; j++)
                {
                    var item = _inventory.GetItem(j);
                    if (item.Data.GetName() == requirements[i].GetName())
                        resources.Add(item);
                }
            }

            return false;
        }

        public void GiveResources(List<Item> resources)
        {
            int count = resources.Count;

            for (int i = 0; i < count; i++)
                _inventory.AddItem(resources[i]);
        }
    }
}