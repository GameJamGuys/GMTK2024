using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    public class TowerHealthView : MonoBehaviour
    {
        private readonly float FadeOutValue = 0;
        private readonly float FadeInValue = 1;

        [SerializeField] private Tower _health;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _changeDuration;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _timerDuration;

        private Slider _slider;
        private bool _isTimerOn = true;
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

            _health.HealthChange += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChange -= OnHealthChanged;
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

        public void OnHealthChanged(float newValue)
        {
            _canvasGroup.DOFade(FadeInValue, _fadeDuration);
            _slider.DOValue(newValue, _changeDuration);
            _isTimerOn = true;
            _timer = _timerDuration;
        }
    }
}