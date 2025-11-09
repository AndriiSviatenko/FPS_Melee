using _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core;
using UnityEngine;

public class LoadingState : IEnterState, IExitState
{
    private readonly GameObject _loadingCurtain;
    private readonly SceneLoader _sceneLoader;
    private readonly string _sceneName;

    public LoadingState(GameObject loadingCurtain, SceneLoader sceneLoader, string sceneName)
    {
        _loadingCurtain = loadingCurtain;
        _sceneLoader = sceneLoader;
        _sceneName = sceneName;
    }

    public void Enter()
    {
        Debug.Log("Enter");
        _loadingCurtain.SetActive(true);
        _sceneLoader.Load(_sceneName, Exit);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        _loadingCurtain.SetActive(false);
    }
}
