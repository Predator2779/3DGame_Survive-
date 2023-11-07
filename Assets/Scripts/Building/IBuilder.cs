using System.Collections.Generic;
using System.Numerics;
using Building.Resources;
using Quaternion = UnityEngine.Quaternion;

namespace Building
{
    public interface IBuilder
    {
        public void Build(Vector3 position, Quaternion rotation);
        public List<Resource> Demolish();
        public void SetConstruction(Construction construction);
        public void GiveResources(List<Resource> resources);
        public void ReturnResources(BuildManager buildManager);
        public bool CanBuild();
    }
}