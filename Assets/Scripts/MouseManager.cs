using System;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _interactionLayer;
    [SerializeField] private float _maxDistance;

    private Ray _ray;
    private Cube _cube;
    public event Action<Cube> clickOnCube;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, _maxDistance, _interactionLayer) == false)
            return;

        if (Input.GetMouseButtonDown(0) == false)
            return;

        _cube = hit.collider.GetComponent<Cube>();

        if (_cube != null)
            clickOnCube?.Invoke(_cube);
    }
}