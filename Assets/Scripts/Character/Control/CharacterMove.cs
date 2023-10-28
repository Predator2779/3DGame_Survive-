using UnityEngine;
using UnityEngine.AI;

namespace Character.Control
{
    public class CharacterMove : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Start() => _agent = GetComponent<NavMeshAgent>();

        public void Move(Vector3 destination) => _agent.SetDestination(destination);
    }
}