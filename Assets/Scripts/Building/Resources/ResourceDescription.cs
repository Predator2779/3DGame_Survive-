using System;

namespace Building.Resources
{
    [Serializable] public struct ResourceDescription
    {
        public void SetDescription(string name, int count)
        {
            Name = name;
            Count = count;
        }
            
        public string Name;
        public int Count;
    }
}