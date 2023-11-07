using System.Collections.Generic;
using System.Linq;
using Building.Resources;
using Character.ItemManagement.Items;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Building
{
    public class Builder : IBuilder
    {
        private Construction _construction;
        private List<Item> _resources;

        public Builder(Construction construction, List<Item> resources)
        {
            _construction = construction;
            _resources = resources;
        }

        public void Build(Vector3 position, Quaternion rotation)
        {
            Debug.Log(
                    $"Builded: {_construction.GetConstruction()}; " +
                    $"on: {position} position; " +
                    $"with: {rotation} rotation;");
        }

        public List<Item> Demolish() => throw new System.NotImplementedException();

        public void ReturnResources(BuildManager buildManager)
        {
            buildManager.GiveResources(_resources);
            
            _resources = null;
        }

        public bool CanBuild() => CheckResources() && _construction != null;
        
        private bool CheckResources()
        {
            var resList = _construction.GetRequirements();
            var length = resList.Count;
        
            for (int i = 0; i < length; i++)
            {
                var name = resList[i].GetName();
                var count = resList[i].GetCount();
        
                var length2 = _resources.Count();
        
                for (int j = 0; j < length2; j++)
                {
                    // if (GetName(_resources[j]) == name
                        // && _resources[j].Count == count)/// количество
                        return true;
                }
            }
        
            return false;
        }

        private string GetName(Item resource) => resource.Data.GetName();
    }
}