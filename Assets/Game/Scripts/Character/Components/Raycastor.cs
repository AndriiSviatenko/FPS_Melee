using UnityEngine;

public class Raycastor : BaseCustomComponent
{
    private Camera _camera;
    private LayerMask _layer;
    private float _distance;

    public void Init(Camera camera, LayerMask layer)
    {
        _camera = camera;
        _layer = layer;
    }
    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    public T Raycast<T>(out bool isHit, out Vector3 hitPoint) where T : Component
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit,
            _distance, _layer))
        {
            isHit = true;
            hitPoint = hit.point;

            if (hit.transform.TryGetComponent(out T target))
            {
                return target;
            }

        }
        isHit = false;
        hitPoint = Vector3.zero;
        return default;
    }
}
