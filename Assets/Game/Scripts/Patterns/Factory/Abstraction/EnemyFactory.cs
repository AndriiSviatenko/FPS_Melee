using UnityEngine;

public class EnemyFactory : GenericFactory<EnemyController>, IService
{
    public override EnemyController Create(EnemyController prefab) =>
        Object.Instantiate(prefab);
}