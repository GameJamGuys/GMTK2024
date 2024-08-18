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

        public void BuildTower(TowerType type)
        {

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
