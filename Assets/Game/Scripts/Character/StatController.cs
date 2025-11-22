using System;

public class StatController : BaseCustomComponent
{
    private SliderView _slider;

    public SliderView GetSlider() => _slider;
    public void Init(SliderView progressSlider)
    {
        _slider = progressSlider;
    }

    public void Increase(float value)
    {
        _slider.Increase(value);
    }
    public void Reduce(float value)
    {
        _slider.Reduce(value);
    }

    public void SetValue(float value)
    {
        _slider.SetValue(value);
    }
}