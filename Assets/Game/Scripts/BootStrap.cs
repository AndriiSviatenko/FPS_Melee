using System;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private GameObject loadingCurtainPrefab;
    [SerializeField] private string sceneName;
    private SceneLoader _sceneLoader;
    private GameObject _loadingCurtain;

    private void Awake()
    {
        var instance = Instantiate(coroutineRunner,transform);
        _loadingCurtain = Instantiate(loadingCurtainPrefab, transform);
        _sceneLoader = new(instance);
        _loadingCurtain.SetActive(true);
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    private void OnLoaded()
    {
        _loadingCurtain.SetActive(false);
    }
}
