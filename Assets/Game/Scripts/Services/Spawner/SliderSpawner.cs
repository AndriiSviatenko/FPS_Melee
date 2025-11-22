using UnityEngine;

public class SliderSpawner : MonoBehaviour
{
    [SerializeField] private SliderContainer slider;
    private SliderFactory _factory;

    private void Awake()
    {
        _factory = ServiceLocator.Container.Single<SliderFactory>();
    }

    public SliderContainer Spawn()
    {
        var instance = _factory.Create(slider);
        return instance;
    }
}
