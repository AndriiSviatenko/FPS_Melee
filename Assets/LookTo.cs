using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTo : MonoBehaviour
{
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    private void LateUpdate()
    {
        if (_target == null) return;

        var dir = new Vector3(_target.position.x, 0, _target.position.z);
        transform.LookAt(dir);
    }
}
