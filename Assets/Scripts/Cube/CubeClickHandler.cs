using System;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private MouseClickDetector _clickDetector;
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> Click;

    private void OnEnable()
    {
        _clickDetector.LeftButtonClicked += OnLeftButtonClicked;
    }

    private void OnDisable()
    {
        _clickDetector.LeftButtonClicked -= OnLeftButtonClicked;
    }

    private void OnLeftButtonClicked()
    {
        if (_raycaster.TryGetRaycastHitCollider(out Collider collider) == false)
            return;

        if(collider.TryGetComponent(out Cube cube))
            Click?.Invoke(cube);
    }

    /*
    private void Update()
    {
        if (_clickDetector.IsLeftButtonClicked() == false)
            return;

        if (_raycaster.TryGetRaycastHitCollider(out Collider collider) == false)
            return;

        _cube = collider.GetComponent<Cube>();

        if (_cube != null)
            Click?.Invoke(_cube);
    }
    */
}