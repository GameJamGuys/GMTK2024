using UnityEngine;
using System.Collections.Generic;
using System;

namespace TowerSystem
{
    [DefaultExecutionOrder(-10)]
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
                    mainTower = main;
            }
        }

        public void AddTower(Tower tower)
        {
            towers.Add(tower);
            OnNewTower?.Invoke(towers.Count);
        }

    }

}
