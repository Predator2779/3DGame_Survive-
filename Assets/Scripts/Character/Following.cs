using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform _huntedObject;
    private Vector3 _offset;

    private void Start() => _offset = transform.position - _huntedObject.position;

    private void LateUpdate() => transform.position = _huntedObject.position + _offset;
}