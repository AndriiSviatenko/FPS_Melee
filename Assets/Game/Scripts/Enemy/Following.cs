using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool isHasTarget;

    public void GetTarget()
    {
        _target = ServiceLocator.Container.Single<CharacterControllerFPS>().transform;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        isHasTarget = _target != null;

        if (!isHasTarget) return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime);
    }
}
