using _project.Scripts.StateMachines.Any.Core;
using System;
using UnityEngine;

public class Loading : IPayloadedState<string>
{
    private readonly StateMachine _stateMachine;
    private readonly GameObject _loadingCurtain;
    private readonly SceneLoader _sceneLoader;

    public Loading(StateMachine stateMachine, GameObject loadingCurtain, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _loadingCurtain = loadingCurtain;
        _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName)
    {
        _loadingCurtain.SetActive(true);
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    private void OnLoaded()
    {
        _stateMachine.Enter<StartGame>();
    }

    public void Exit()
    {
        _loadingCurtain.SetActive(false);
    }
}
