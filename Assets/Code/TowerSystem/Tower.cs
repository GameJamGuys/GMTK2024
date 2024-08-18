using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Damage;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

namespace TowerSystem
{
    public class Tower : Target
    {
        [field:SerializeField] public TowerUpgradeConfig UpgradeConfig {get; private set;}
        [field:SerializeField] public BaseEffectTower EffectTower {get; private set;}
        [SerializeField] private TowerLevelVisual towerLevelVisual;
        
        public TowerUpdateView UpgradeView {get; private set;}

        private float currentHealth;
        private int upgradeLevel = 0;

        public bool IsLastUpgrade => upgradeLevel >= UpgradeConfig.Levels.Count - 1;

        protected virtual void Start()
        {
            if (!IsLastUpgrade)
            {
                currentHealth = UpgradeConfig.Levels[upgradeLevel].Config.Health;
            }

            GetUpgradeView();
        }

        public event Action<Tower> OnDie;
        public event Action<float> HealthChange;

        public void ShowUpgrades()
        {
            if (UpgradeView == null)
            {
                GetUpgradeView();
            }
            UpgradeView.gameObject.SetActive(true);
        }

        public void UpgradeLevel()
        {
            if (!CanUpgrade())
            {
                return;
            }

            upgradeLevel += 1;
            
            TowerUpgradeLevel nextLevel = UpgradeConfig.Levels[upgradeLevel];
            
            foreach (var resource in nextLevel.Resources)
            {
                WalletData.RemoveResource(resource.type, resource.amount);
            }

            EffectTower.ChangeConfig(nextLevel.Config);
            currentHealth = nextLevel.Config.Health;
            towerLevelVisual.LevelUp(upgradeLevel);
        }
        
        public void HideUpgrades()
        {
            if (UpgradeView == null)
            {
                GetUpgradeView();
            }
            UpgradeView.gameObject.SetActive(false);
        }
        
        public void EnableHoverUpgrades()
        {
            if (UpgradeView == null)
            {
                GetUpgradeView();
            }
            UpgradeView.gameObject.SetActive(false);
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
        
        public bool CanUpgrade()
        {
            if (IsLastUpgrade)
            {
                return false;
            }

            foreach (var resource in UpgradeConfig.Levels[upgradeLevel + 1].Resources)
            {
                if (WalletData.GetResourceCount(resource.type) < resource.amount)
                {
                    return false;
                }
            }

            return true;
        }

        public void GetHeal(float heal)
        {
            HealthChange?.Invoke(currentHealth);
            Debug.Log("Tower GetHeal");
        }

        private void GetUpgradeView()
        {
            UpgradeView = GetComponentInChildren<TowerUpdateView>(true);
        }
    }

    [Serializable]
    public class TowerUpgradeConfig
    {
        public List<TowerUpgradeLevel> Levels;
    }

    [Serializable]
    public class TowerUpgradeLevel
    {
        public List<TowerShop.ResCost> Resources;
        public AreaEffectTowerSO Config;
    }
}