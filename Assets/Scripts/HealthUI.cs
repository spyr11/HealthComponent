using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _slowSlider;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private bool _isValueChanged;

    private void OnEnable()
    {
        _healthComponent.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _healthComponent.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slowSlider.value = _slider.value;

        _textMeshPro.text = $"{_healthComponent.MaxHealth}/{_healthComponent.MaxHealth}";
    }

    private void Update()
    {
        ChangeValueSlowSlider();
    }

    private void OnHealthChanged(float value)
    {
        float newValue = value / _healthComponent.MaxHealth;

        ChangeTextValue(value);

        ChangeValueSlider(newValue);

        _isValueChanged = true;
    }

    private void ChangeTextValue(float value)
    {
        _textMeshPro.text = $"{value}/{_healthComponent.MaxHealth}";
    }

    private void ChangeValueSlider(float value)
    {
        _slider.value = value;
    }

    private void ChangeValueSlowSlider()
    {
        if (_slider.value == _slowSlider.value)
        {
            _isValueChanged = false;
        }

        if (_isValueChanged)
        {
            float newValue = _slider.value;

            _slowSlider.value = _slowSlider.value > newValue ? _slowSlider.value : newValue;

            float current = _slowSlider.value;
            float delta = Mathf.Abs(current - newValue);

            _slowSlider.value = Mathf.MoveTowards(current, newValue, delta * Time.deltaTime);
        }
    }
}
