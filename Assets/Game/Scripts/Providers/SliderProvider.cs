using UnityEngine;

public class SliderProvider : MonoBehaviour, IService
{
    [SerializeField] private SliderSpawner sliderSpawner;
    private Vector3 _reflectVector = new Vector3(0, -180, 0);

    public SliderContainer GetSlider(float minValue, float value, float maxValue, Vector3 position, Quaternion rotation, Transform parent)
    {
        var slider = sliderSpawner.Spawn();

        slider.View.SetRange(minValue, maxValue);
        slider.View.SetValue(value);

        slider.transform.SetPos(position);
        slider.transform.SetRotate(rotation);
        slider.transform.SetParent(parent);

        return slider;
    }
}
