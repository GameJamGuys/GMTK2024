using System;
using Cysharp.Threading.Tasks;
using Damage;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : Target
    {
        [SerializeField] protected float health;
        
        protected float currentHealth;
        private TowerUpgradesView upgradeCanvas;

        private void Start()
        {
            currentHealth = health;
            upgradeCanvas = GetComponentInChildren<TowerUpgradesView>(true);
        }

        public event Action<Tower> OnDie;
        public event Action<float> HealthChange;

        public void ShowUpgrades()
        {
            upgradeCanvas.gameObject.SetActive(true);
        }
        
        public void HideUpgrades()
        {
            upgradeCanvas.gameObject.SetActive(false);
        }

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