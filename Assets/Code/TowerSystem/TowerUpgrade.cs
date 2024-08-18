using UnityEngine;

namespace TowerSystem
{
    public class TowerUpgrade : MonoBehaviour
    {
        private void OnEnable()
        {
            WalletData.OnChangeWallet += CheckUpgrade;
            TowerManager.Instance.OnNewTower += CheckUpgrade;
        }

        private void OnDisable()
        {
            WalletData.OnChangeWallet -= CheckUpgrade;
            TowerManager.Instance.OnNewTower -= CheckUpgrade;
        }

        private void CheckUpgrade(int value)
        {
            CheckUpgrade();
        }

        private void CheckUpgrade(Resource.Types type)
        {
            CheckUpgrade();
        }

        private void CheckUpgrade()
        {
            foreach (Tower tower in TowerManager.Instance.GetTowers())
            {
                if (tower.IsLastUpgrade)
                {
                    continue;
                }

                if (CanUpgrade(tower))
                {
                    tower.ShowUpgrades();
                }
                else
                {
                    tower.HideUpgrades();
                }
            }
        }

        private bool CanUpgrade(Tower tower)
        {
            foreach (var resource in tower.UpgradeConfig.Resources)
            {
                if (WalletData.GetResourceCount(resource.type) < resource.amount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}