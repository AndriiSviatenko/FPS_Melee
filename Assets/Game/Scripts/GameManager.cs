using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterSpawner characterSpawner;
    [SerializeField] private Following enemyPrefab;
    [SerializeField] private CharacterControllerFPS prefab;

    private void Awake()
    {
        var enemy = ServiceLocator.Container.Single<EnemyFactory>().Create(enemyPrefab);
        var instance = ServiceLocator.Container.Single<CharacterFactory>().Create(prefab);
        ServiceLocator.Container.RegisterSingle<CharacterControllerFPS>(instance);

        Debug.Log($"Instance {instance != null}");
        enemy.GetTarget();
    }
}
