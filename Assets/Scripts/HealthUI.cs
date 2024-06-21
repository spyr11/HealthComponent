using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    public float MaxHealth => _health.MaxHealth;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void ChangeValue(float value);

    private void OnHealthChanged(float value)
    {
        ChangeValue(value);
    }
}