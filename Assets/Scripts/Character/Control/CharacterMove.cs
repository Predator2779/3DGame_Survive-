using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    private NavMeshAgent _agent;

    private void Start() => _agent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                _agent.SetDestination(hit.point);
        }
    }
}