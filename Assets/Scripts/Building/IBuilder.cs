using System.Collections.Generic;
using System.Numerics;
using Character.ItemManagement.Items;
using Quaternion = UnityEngine.Quaternion;

namespace Building
{
    public interface IBuilder
    {
        public void Build(Vector3 position, Quaternion rotation);
        public List<Item> Demolish();
        public void ReturnResources(BuildManager buildManager);
        public bool CanBuild();
    }
}