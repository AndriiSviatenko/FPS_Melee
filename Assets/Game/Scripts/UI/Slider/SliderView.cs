using DG.Tweening;
using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    public event Action<int> ChangeEvent;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image fillImage;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 100f;

    [ReadOnly(true)]
    [SerializeField] private float currentValue;

    private void Start()
    {
        UpdateFillAmount();
    }

    public void SetRange(float min, float max)
    {
        minValue = min;
        maxValue = max;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        UpdateFillAmount();
    }

    public virtual void Show()
    {
        canvasGroup.DOFade(1, 0.2f);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public virtual void Hide()
    {
        canvasGroup.DOFade(0, 0.2f);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    [ContextMenu("IncreaseTest")]
    public void Increase()
    {
        SetValue(currentValue + 1);
        ChangeEvent?.Invoke((int)currentValue);
    }

    [ContextMenu("ReduceTest")]
    public void Reduce()
    {
        SetValue(currentValue - 1);
        ChangeEvent?.Invoke((int)currentValue);
    }

    [ContextMenu("NewReduceTest")]
    public void Reduce(float amount)
    {
        SetValue(currentValue - amount);
        ChangeEvent?.Invoke((int)currentValue);
    }

    [ContextMenu("NewIncreaseTest")]
    public void Increase(float amount)
    {
        SetValue(currentValue + amount);
        ChangeEvent?.Invoke((int)currentValue);
    }

    public void SetValue(float value)
    {
        Debug.Log($"Set value {value} in {currentValue}");

        currentValue = Mathf.Lerp(currentValue, value, Time.deltaTime);
        currentValue = Mathf.Clamp(value, minValue, maxValue);

        Debug.Log($"Seted value {value} in {currentValue}");
        UpdateFillAmount();
        ChangeEvent?.Invoke((int)currentValue);
    }

    private void UpdateFillAmount()
    {
        if (fillImage != null)
            fillImage.fillAmount = Mathf.InverseLerp(minValue, maxValue, currentValue);
    }
}
