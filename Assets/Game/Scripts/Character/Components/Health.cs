using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private StatController statController;
    public int maxHealth;
    private int _currentHealth;
    private SliderView _slider;

    public void SetSlider(SliderView slider)
    {
        _slider = slider;
        statController.Init(_slider);
        statController.StartComponent();
    }

    private void Awake() =>
        _currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        statController.SetValue(_currentHealth);

        if (_currentHealth <= 0)
        { 
            Death();
            Destroy(statController.GetSlider().gameObject);
        }
    }

    private void Death() =>
        Destroy(gameObject);
}
