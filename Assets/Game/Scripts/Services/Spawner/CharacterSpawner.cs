using _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterControllerFPS character;
    private CharacterFactory _characterFactory;

    private void Awake()
    {
        _characterFactory = ServiceLocator.Container.Single<CharacterFactory>();
    }

    public CharacterControllerFPS Spawn()
    {
        return _characterFactory.Create(character);
    }
}
