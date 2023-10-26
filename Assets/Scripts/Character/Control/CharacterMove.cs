using General;
using UnityEngine;
using UnityEngine.AI;

namespace Character.Control
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private Camera _cam;

        private NavMeshAgent _agent;
        private bool _canMove;
    
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        
            EventHandler.OnMouseButtonUp.AddListener(Move);
            EventHandler.OnButtonUp.AddListener(SwitchMove);
        }

        private void Move(int mouseButton)
        {
            if (_canMove || mouseButton != 0) return;
        
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                _agent.SetDestination(hit.point);
        }

        private void SwitchMove(KeyCode button)
        {
            if (button != KeyCode.Tab) return;

            if (!_canMove) _canMove = true;
            else _canMove = false;
        }
    }
}