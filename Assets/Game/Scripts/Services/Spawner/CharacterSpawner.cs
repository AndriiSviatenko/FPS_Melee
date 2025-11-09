using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    private CharacterFactory _characterFactory;

    private void Awake()
    {
        _characterFactory = new();
    }
    private void Start()
    {
        _characterFactory.Create(character);
    }
}
