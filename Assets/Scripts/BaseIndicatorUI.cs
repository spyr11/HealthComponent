using UnityEngine;

public abstract class BaseIndicatorUI : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _indicator;

    private IIndicator _changeable;

    public float MaxValue => _changeable.MaxValue;

    private void OnValidate()
    {
        if (_indicator is not IIndicator)
        {
            Debug.Log(_indicator.name + " need implement " + nameof(IIndicator));

            _indicator = null;
        }
    }

    private void Awake()
    {
        _changeable = (IIndicator)_indicator;
    }

    private void OnEnable()
    {
        _changeable.Changed += OnValueChanged;
    }

    private void OnDisable()
    {
        _changeable.Changed -= OnValueChanged;
    }

    protected abstract void ChangeValue(float value);

    private void OnValueChanged(float value)
    {
        ChangeValue(value);
    }
}