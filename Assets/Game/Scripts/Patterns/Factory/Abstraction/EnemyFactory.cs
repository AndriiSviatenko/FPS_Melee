using UnityEngine;

public class EnemyFactory : GenericFactory<Following>, IService
{
    public override Following Create(Following prefab) =>
        Object.Instantiate(prefab);
}