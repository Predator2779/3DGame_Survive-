using System;
using System.Collections.Generic;
using Character.ItemManagement.Items;
using UnityEngine;

namespace Building.Resources
{
    [Serializable] public class ResourcesPackage
    {
        [SerializeField] private List<Resource> _resources = new();

        public ItemData GetResourceData(int index) => _resources[index].GetData();

        public int GetCountResources(int index) => _resources[index].GetCount();

        public int GetCountPackage() => _resources.Count;
        
        public void AddResource(Resource resource) => _resources.Add(resource);

        public void RemoveResource(Resource resource)
        {
            if (_resources.Contains(resource))
                _resources.Remove(resource);
        }
        
        public void GiveResources(IBuilder builder)
        {
            builder.GiveResources(_resources);
        }
    }
}