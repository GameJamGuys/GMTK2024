using System;
using DG.Tweening;
using UnityEngine;

namespace TowerSystem
{
    public class MainTower : Tower
    {
        private readonly float Duration = 0.5f;
        public TowerType towerType = TowerType.Range;

        [SerializeField] private TowerHealthView _healthView;
        [SerializeField] private float _scaleModifier;

        private float _startScale;

        private void OnEnable()
        {
            if (_healthView == null)
            {
                throw new ArgumentNullException(nameof(_healthView));
            }

            _startScale = _healthView.transform.localScale.x;
        }
        
        public void IncreaseMaxHealth(uint modifier)
        {
            float newScale = _startScale + _scaleModifier;
            health += modifier;
            currentHealth = health;
            _healthView.transform.DOScaleX(newScale, Duration);
        }
    }
}