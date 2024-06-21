
using System;
using UnityEngine;

public class Health : MonoBehaviour, IIndicator
{
    [SerializeField] private ActionButton _damage;
    [SerializeField] private ActionButton _heal;
    [SerializeField, Range(0, 300)] private float _maxHealth;

    private float _currentHealth;

    public event Action<float> Changed;

    public float MaxValue => _maxHealth;

    private void Awake()
    {
        _currentHealth = MaxValue;
    }

    private void OnEnable()
    {
        _damage.ValueChanged += Decrease;
        _heal.ValueChanged += Increase;
    }

    private void OnDisable()
    {
        _damage.ValueChanged -= Decrease;
        _heal.ValueChanged -= Increase;
    }

    private void Start()
    {
        Changed?.Invoke(_currentHealth);
    }

    private void Increase(float value)
    {
        if (value <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, MaxValue);

        Changed?.Invoke(_currentHealth);
    }

    private void Decrease(float value)
    {
        if (value <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth - value, 0, MaxValue);

        Changed?.Invoke(_currentHealth);
    }
}