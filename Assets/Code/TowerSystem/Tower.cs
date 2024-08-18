using System;
using Cysharp.Threading.Tasks;
using Damage;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : Target
    {
        [SerializeField] private float health;
        
        private float currentHealth;

        private void Start()
        {
            currentHealth = health;
        }

        public event Action<Tower> OnDie;
        public event Action<float> HealthChange;

        public override void GetDamage(float damage)
        {
            currentHealth -= damage;
            HealthChange?.Invoke(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDie?.Invoke(this);
            }
        }

        public void GetHeal(float heal)
        {
            HealthChange?.Invoke(currentHealth);
            Debug.Log("Tower GetHeal");
        }
    }
}