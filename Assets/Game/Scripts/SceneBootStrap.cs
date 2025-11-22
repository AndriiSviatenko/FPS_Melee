using System;
using UnityEngine;

public class SceneBootStrap : MonoBehaviour
{
    [SerializeField] private SliderProvider sliderProvider;
    [SerializeField] private CharacterSpawner characterSpawner;
    [SerializeField] private EnemyController enemyPrefab;

    [SerializeField] private AudioSystem audioSystem;
    [SerializeField] private Camera cam;

    [SerializeField] private Transform staminaPoint;
    [SerializeField] private Transform worldCanvas;

    private CharacterControllerFPS _character;
    private SliderContainer _staminaSlider;
    private EnemyController _enemy;
    private SliderContainer _enemyHealthBar;
    private SliderHelper _sliderHelper;

    private void Awake()
    {
        _sliderHelper = ServiceLocator.Container.Single<SliderHelper>();
    }

    private void Start()
    {
        _character = characterSpawner.Spawn();
        ServiceLocator.Container.RegisterSingle<CharacterControllerFPS>(_character);
        SetupCharacter();

        _staminaSlider = sliderProvider.GetSlider(0, _character.attackSpeed, _character.attackSpeed,
            staminaPoint.position, Quaternion.identity, staminaPoint);

        _sliderHelper.SetupCorrectSide(Vector3.zero, _staminaSlider);

        PostSetupUI();

        _enemy = ServiceLocator.Container.Single<EnemyFactory>().Create(enemyPrefab);
        SetupEnemy();

        _enemyHealthBar = sliderProvider.GetSlider(0, _enemy.Health.maxHealth, _enemy.Health.maxHealth,
            _enemy.HealthBarPointProvider.Point.position, Quaternion.identity, worldCanvas);

        _sliderHelper.SetupCorrectSide(new Vector3(0, -180, 0), _enemyHealthBar);
        _sliderHelper.ChangeSize(2f, 0.2f, _enemyHealthBar);
        _sliderHelper.SetFollow(_enemy.HealthBarPointProvider.Point, _enemyHealthBar);
        _sliderHelper.SetLook(cam.transform, _enemyHealthBar);

        PostSetupEnemyUI();
    }

    private void SetupCharacter()
    {
        _character.SetAudioSystem(audioSystem);
        _character.SetCamera(cam);
    }
    private void PostSetupUI()
    {
        _character.SetSlider(_staminaSlider);
    }

    private void SetupEnemy()
    {
        _enemy.Following.GetTarget();
    }
    private void PostSetupEnemyUI()
    {
        _enemy.Health.SetSlider(_enemyHealthBar.View);
    }
}
