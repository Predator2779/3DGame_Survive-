using System.Collections.Generic;
using System.Numerics;
using Building.Resources;
using Quaternion = UnityEngine.Quaternion;

namespace Building
{
    public interface IBuilder
    {
        public void Build(ResourcesPackage resourcesPackage, Vector3 position, Quaternion rotation);
        public ResourcesPackage Demolish();
        public bool CheckRequirements(ResourcesPackage resourcesPackage);

        public void GiveResources(List<Resource> resources);
    }
}