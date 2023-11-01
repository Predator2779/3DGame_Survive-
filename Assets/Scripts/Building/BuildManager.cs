using System.Collections.Generic;
using Building.Resources;
using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Spawners;
using UnityEngine;

namespace Building
{
    [RequireComponent(typeof(ItemSpawner))]
    public class BuildManager : MonoBehaviour
    {
        [SerializeField] private Construction TestConstruction;//
        [SerializeField] private Inventory _inventory;

        private IBuilder _builder;

        private void Start()
        {
            TryBuildConstruction(TestConstruction, _inventory);//
        }

        public void TryBuildConstruction(Construction construction, Inventory inventory)
        {
            _builder = new Builder(construction);

            // if (builder.TryBuild())
        }

        public void GiveResources(List<Resource> resources)
        {
            /// resources => inventory
        }
    }
}