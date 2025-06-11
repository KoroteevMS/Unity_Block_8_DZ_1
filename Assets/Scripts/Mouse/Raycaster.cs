using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _ignore;
    [SerializeField] private float _maxDistance;

    private Ray _ray;

    public bool TryGetRaycastHitCollider(out Collider hitCollider)
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(_ray, out RaycastHit hit, _maxDistance, _ignore);
        hitCollider = hit.collider;

        return isHit;
    }
}