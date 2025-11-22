using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPointProvider : MonoBehaviour
{
    [SerializeField] private Transform point;
    public Transform Point => point;
}
