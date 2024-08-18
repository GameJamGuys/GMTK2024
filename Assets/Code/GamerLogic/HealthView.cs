using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Coroutine _changeValue;
    private Slider _slider;
    private float _filled;

    private void OnEnable()
    {
        if (_health == null)
        {
            throw new ArgumentNullException(nameof(_health));
        }

        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnHealthChanged(float newValue)
    {
        if (_changeValue != null)
            StopCoroutine(_changeValue);

        _changeValue = StartCoroutine(ChangeValue(newValue));
    }

    private IEnumerator ChangeValue(float newValue)
    {
        while (_filled != newValue)
        {
            _slider.value = Mathf.MoveTowards(_filled, newValue, _speed * Time.deltaTime);
            _filled = _slider.value;
            yield return null;
        }
    }
}