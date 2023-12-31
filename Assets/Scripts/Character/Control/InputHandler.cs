﻿using General;
using UnityEngine;

namespace Character.Control
{
    [RequireComponent(typeof(Person))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Person _person;
        [SerializeField] private Camera _cam;

        private RaycastHit _hit;

        private void Start() => _person ??= GetComponent<Person>();

        private void Update()
        {
            SetRay();
            CheckKeys();
        }

        private void CheckKeys()
        {
            if (Input.GetKeyUp(KeyCode.Tab)) DisplayInventory();

            if (Input.GetMouseButtonUp(0)) MoveCharacter();
        }

        private void SetRay()
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) _hit = hit;
        }

        private void DisplayInventory()
        {
            _person.GetInventory().SwitchDisplay();

            EventHandler.OnInventoryButtonUp?.Invoke();
        }

        private void MoveCharacter()
        {
            if (!_person.GetInventory().IsDisplayed)
                _person.GetCharacterMove().Move(_hit.point);
        }
    }
}