using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Damage;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerSystem
{
    public class Tower : Target
    {
        [SerializeField] private float health;
        [field:SerializeField] public TowerUpgradeConfig UpgradeConfig {get; private set;}
        
        private float currentHealth;
        private TowerUpdateView upgradeView;
        private int uprgadeLevel;

        public bool IsLastUpgrade => uprgadeLevel == UpgradeConfig.Resources.Count - 1;

        protected virtual void Start()
        {
            currentHealth = health;
            GetUpgradeView();
        }

        public event Action<Tower> OnDie;
        public event Action<float> HealthChange;

        public void ShowUpgrades()
        {
            if (upgradeView == null)
            {
                GetUpgradeView();
            }
            upgradeView.gameObject.SetActive(true);
        }
        
        public void HideUpgrades()
        {
            if (upgradeView == null)
            {
                GetUpgradeView();
            }
            upgradeView.gameObject.SetActive(false);
        }
        
        public void EnableHoverUpgrades()
        {
            if (upgradeView == null)
            {
                GetUpgradeView();
            }
            upgradeView.gameObject.SetActive(false);
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

        private void GetUpgradeView()
        {
            upgradeView = GetComponentInChildren<TowerUpdateView>(true);
        }
    }

    [Serializable]
    public class TowerUpgradeConfig
    {
        public List<TowerShop.ResCost> Resources;
    }
}