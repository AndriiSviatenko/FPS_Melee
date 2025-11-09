using UnityEngine;

public class CharacterFactory : GenericFactory<CharacterController>
{
    public override CharacterController Create(CharacterController prefab) =>
        Object.Instantiate(prefab);
}