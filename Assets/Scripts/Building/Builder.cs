using System.Collections.Generic;
using System.Linq;
using Building.Resources;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Building
{
    public class Builder : IBuilder
    {
        private Construction _construction;
        private List<Resource> _resources;

        public Builder(Construction construction) => _construction = construction;

        public void Build(Vector3 position, Quaternion rotation)
        {
            Debug.Log(
                    $"Builded: {_construction.GetConstruction()}; " +
                    $"on: {position} position; " +
                    $"with: {rotation} rotation;");
        }

        public List<Resource> Demolish() => throw new System.NotImplementedException();

        public void SetConstruction(Construction construction) => _construction = construction;

        public void GiveResources(List<Resource> resources) => _resources = resources;

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
                var name = resList[i].Name;
                var count = resList[i].Count;

                var length2 = _resources.Count();

                for (int j = 0; j < length2; j++)
                {
                    if (GetName(_resources[j]) == name &&
                        _resources[j].GetCount() == count)
                        return true;
                }
            }

            return false;
        }

        private string GetName(Resource resource) => resource.GetItem().Data.GetName();
    }
}