using _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterControllerFPS character;
    private CharacterFactory _characterFactory;

    public CharacterControllerFPS Spawn()
    {
        _characterFactory = ServiceLocator.Container.Single<CharacterFactory>();
        var instance = _characterFactory.Create(character);
        return instance;
    }
}
