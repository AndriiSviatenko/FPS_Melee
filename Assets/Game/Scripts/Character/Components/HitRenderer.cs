using UnityEngine;

public class HitRenderer : BaseCustomComponent
{
    private GameObject _hitEffect;
    public void Init(GameObject hitEffect)
    {
        _hitEffect = hitEffect;
    }
    public void Render(Vector3 position)
    {
        GameObject instance = Instantiate(_hitEffect, position, Quaternion.identity);
        Destroy(instance, 2);
    }
}