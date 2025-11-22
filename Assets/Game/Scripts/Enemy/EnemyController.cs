using UnityEngine;

public class EnemyController : MonoBehaviour, IService
{
    [field:SerializeField] public Health Health { get; private set; }
    [field:SerializeField] public HealthBarPointProvider HealthBarPointProvider { get; private set; }
    [field:SerializeField] public Following Following { get; private set; }
}

//UIController
