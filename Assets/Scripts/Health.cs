
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private ActionButton _damage;
    [SerializeField] private ActionButton _heal;
    [field: SerializeField, Range(0, 300)] public float MaxHealth { get; private set; }

    private float _currentHealth;

    public event Action<float> HealthChanged;

    private void Awake()
    {
        _currentHealth = MaxHealth;
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
        HealthChanged?.Invoke(_currentHealth);
    }

    private void Increase(float value)
    {
        if (value <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, MaxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }

    private void Decrease(float value)
    {
        if (value <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth - value, 0, MaxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}
