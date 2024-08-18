using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthView : MonoBehaviour
{
    private readonly float FadeOutValue = 0;
    private readonly float FadeInValue = 1;

    [SerializeField] private Health _health;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _changeDuration;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _timerDuration;
    
    private Slider _slider;
    private bool _isTimerOn;
    private float _timer;

    private void OnEnable()
    {
        if (_health == null)
        {
            throw new ArgumentNullException(nameof(_health));
        }

        if (_canvasGroup == null)
        {
            throw new ArgumentNullException(nameof(_canvasGroup));
        }
        
        _slider.maxValue = _health.Max;
        _slider.value = _slider.maxValue;
        OnHealthChanged(_slider.value);

        _health.HealthChanged += OnHealthChanged;
        _health.Died += OnDead;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
        _health.Died -= OnDead;
    }
    
    private void Update()
    {
        if (_isTimerOn)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _canvasGroup.DOFade(FadeOutValue, _fadeDuration);
                _isTimerOn = false;
            }
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    
    private void OnHealthChanged(float newValue)
    {
        _canvasGroup.DOFade(FadeInValue, _fadeDuration);
        _slider.DOValue(newValue, _changeDuration);
        _isTimerOn = true;
        _timer = _timerDuration;
    }

    private void OnDead()
    {
        _isTimerOn = false;
        _canvasGroup.DOFade(FadeOutValue, _fadeDuration);
        _slider.DOKill();
    }
    
    
}