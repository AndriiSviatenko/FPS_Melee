using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTo : MonoBehaviour
{
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        if (_target == null) 
            return;

        transform.position = (_target.position);
    }
}
