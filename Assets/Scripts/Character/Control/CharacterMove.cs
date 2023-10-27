using System;
using UnityEngine;
using UnityEngine.AI;
using EventHandler = General.EventHandler;

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

            EventHandler.OnInventoryButtonUp.AddListener(SwitchMove);
        }

        public void Move()
        {
            if (_canMove) return;

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                _agent.SetDestination(hit.point);
        }

        private void SwitchMove()
        {
            if (!_canMove) _canMove = true;
            else _canMove = false;
        }

        private void OnDestroy() => EventHandler.OnInventoryButtonUp.RemoveListener(SwitchMove);
    }
}