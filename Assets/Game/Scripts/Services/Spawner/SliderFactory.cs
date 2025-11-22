using UnityEngine;

public class SliderFactory : GenericFactory<SliderContainer>, IService
{
    public override SliderContainer Create(SliderContainer prefab) =>
        Object.Instantiate(prefab);
}
