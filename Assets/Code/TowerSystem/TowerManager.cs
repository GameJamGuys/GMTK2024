using UnityEngine;
using System.Collections.Generic;
using System;

namespace TowerSystem
{
    public enum MainTowerUpgrades
    {
        AttackSpeedIncrease,
        BuffEffectIncrease,
        CooldownReduce,
        GnomeSpeedIncrease,
        RadiusEffectIncrease
    }

    [DefaultExecutionOrder(-20)]
    public class TowerManager : StaticInstance<TowerManager>
    {
        

        [SerializeField]
        List<Tower> towers;

        public MainTower mainTower;

        public event Action<int> OnNewTower;

        public int TowersCount => towers.Count;

        private void Start()
        {
            towers = new List<Tower>(GetComponentsInChildren<Tower>());

            foreach(Tower tower in towers)
            {
                if (tower.TryGetComponent(out MainTower main))
                    tower.OnDie += TowerDie;
                    mainTower = main;
            }

            //mainTower.GetComponentInChildren<BaseEffectTower>().GetComponent<SphereCollider>().radius = 15;
        }

        public void AddTower(Tower tower)
        {
            tower.OnDie += TowerDie;
            towers.Add(tower);
            OnNewTower?.Invoke(towers.Count);
        }

        private void TowerDie(Tower tower)
        {
            tower.OnDie -= TowerDie;
            towers.Remove(tower);
            Destroy(tower.gameObject);
        }
    }

}
