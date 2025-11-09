using _project.Scripts.StateMachines.Any.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private GameObject loadingCurtainPrefab;
    [SerializeField] private string sceneName;

    private StateMachine _stateMachine;
    private Loading _loading;
    private StartGame _startGame;

    private SceneLoader _sceneLoader;
    private GameObject _loadingCurtain;

    private void Awake()
    {
        var instance = Instantiate(coroutineRunner, transform);
        _loadingCurtain = Instantiate(loadingCurtainPrefab, transform);
        _sceneLoader = new(instance);

        _stateMachine = new();
        _loading = new(_stateMachine, _loadingCurtain, _sceneLoader);
        _startGame = new(_stateMachine);
        var dirStates = new Dictionary<Type, IExitableState>
        {
            { typeof(Loading), _loading },
            { typeof(StartGame), _startGame }
        };

        _stateMachine.SetStates(dirStates);
        _stateMachine.Enter<Loading, string>(sceneName);
    }
}
