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

                if (tower.CanUpgrade())
                {
                    tower.ShowUpgrades();
                }
                else
                {
                    tower.HideUpgrades();
                }
            }
        }
    }
}