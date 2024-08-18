using UnityEngine;
using System.Collections.Generic;

namespace TowerSystem
{
    public class TowerShop : StaticInstance<TowerShop>
    {
        public void BuildRange() => BuildTower(TowerType.Range);
        public void BuildMelee() => BuildTower(TowerType.Melee);
        public void BuildSupport() => BuildTower(TowerType.Support);
        public void BuildMagnet() => BuildTower(TowerType.Magnet);
        public void BuildHeal() => BuildTower(TowerType.Heal);

        [SerializeField] GameObject GameUI;
        [SerializeField] PauseMenu pause;
        [SerializeField] GameObject holder;

        public bool isOpen;

        [Space]
        [SerializeField]
        List<TowerCost> towerCosts;
        
        
        private TowerCost GetTowerCost(TowerType type)
        {
            foreach (TowerCost cost in towerCosts)
            {
                if (cost.towerType == type)
                {
                    return cost;
                }
            }
            return null;
        }

        public void BuildTower(TowerType type)
        {
            CloseShop();

            TowerCost cost = GetTowerCost(type);

            foreach (ResCost resCost in cost.resources)
            {
                WalletData.RemoveResource(resCost.type, resCost.amount);
            }

            TowerBuilder.Instance.BuildTower(type);
        }
        public bool CheckTowerCost(TowerType type)
        {
            TowerCost cost = GetTowerCost(type);
            foreach(ResCost resCost in cost.resources)
            {
                int wallet = WalletData.GetResourceCount(resCost.type);
                if (wallet <= resCost.amount)
                    return false;
            }
            return true;
        }

        public void CloseShop()
        {
            isOpen = false;
            holder.SetActive(false);
            GameUI.SetActive(true);
            pause.TogglePauseGame();
        }

        public void OpenShop()
        {
            if (isOpen) return;
            bool check = TowerBuilder.Instance.CheckArea();
            print(check);

            if (check)
            {
                isOpen = true;
                holder.SetActive(true);
                GameUI.SetActive(false);
                pause.TogglePauseGame();
            }
        }

        [System.Serializable]
        public class TowerCost
        {
            public TowerType towerType;
            public List<ResCost> resources;
        }

        [System.Serializable]
        public class ResCost
        {
            public Resource.Types type;
            public int amount;
        }
    }

}
