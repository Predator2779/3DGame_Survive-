using System;
using UnityEngine;

namespace Building.Resources
{
    [Serializable] public struct ResourceDescription
    {
        [SerializeField] private string _name;
        [SerializeField] private int _count;
        
        public void SetDescription(string name, int count)
        {
            _name = name;
            _count = count;
        }
        
        public string GetName() => _name;
        public int GetCount() => _count;
    }
}