using System.Collections.Generic;
using UnityEngine;

namespace Building.Resources
{
    public class Construction : MonoBehaviour
    {
        [SerializeField] private List<ResourceDescription> _requireResources;
        [SerializeField] private GameObject _buildPrefab;

        public GameObject GetConstruction() => _buildPrefab;
        public List<ResourceDescription> GetRequirements() => _requireResources;
    }
}