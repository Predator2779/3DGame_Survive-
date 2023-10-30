using System.Collections.Generic;
using Building.Resources;
using Character.ItemManagement.Items;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Building
{
    public class MachineBuilder : IBuilder
    {
        [SerializeField] private ResourcesPackage _resourcesPackage;
        
        private List<Resource> _resources;
        
        public void Build(ResourcesPackage resourcesPackage, Vector3 position, Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        public ResourcesPackage Demolish() => throw new System.NotImplementedException();

        public bool CheckRequirements(ResourcesPackage resourcesPackage)
        {
            // int count = _resourcesPackage.GetCountPackage();
            //
            // for (int i = 0; i < count; i++)
            //     if (FindRes(_resourcesPackage,
            //                 _resourcesPackage.GetResourceData(i).GetName(), 
            //                 out ItemData itemData))
            //         if (itemData.)

            return true;///
        }

        // private bool FindRes(ResourcesPackage package, string name, out Resource resource)
        // {
        //     int count = package.GetCountPackage();
        //     
        //     for (int i = 0; i < count; i++)
        //         if (package.GetResourceData(i).GetName() == name)
        //         {
        //             resource = package.GetResourceData(i);
        //
        //             return true;
        //         }
        //
        //     resource = null;
        //     return false;
        // }
        
        public void GiveResources(List<Resource> resources)
        {
            throw new System.NotImplementedException();
        }
    }
}