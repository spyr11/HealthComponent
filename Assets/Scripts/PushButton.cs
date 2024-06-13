
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PushButton : MonoBehaviour
{
    private Button _button;
    private float _value = 15f;

    public event Action<float> ValueChanged;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
      _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        ValueChanged?.Invoke(_value);
    }
}
