using UnityEngine;
using System.Collections.Generic;

namespace TowerSystem
{
    public class TowerManager : StaticInstance<TowerManager>
    {
        [SerializeField]
        List<Tower> towers;

        public int TowersCount => towers.Count;

        private void Start()
        {
            towers = new List<Tower>(GetComponentsInChildren<Tower>());
        }

        public void AddTower(Tower tower) => towers.Add(tower);

    }

}
