using UnityEngine;

public class CharacterFactory : GenericFactory<CharacterControllerFPS>, IService
{
    public override CharacterControllerFPS Create(CharacterControllerFPS prefab) =>
        Object.Instantiate(prefab);
}
