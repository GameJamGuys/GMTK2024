using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace TowerSystem
{
    public class TowerBuilder : StaticInstance<TowerBuilder>
    {
        [SerializeField] PlayerInputRouter player;
        [SerializeField] GnomeVisual visual;
        [Space]
        [SerializeField]
        List<SideTower> sideTowers;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if(CheckArea())
                    BuildTower(TowerType.Range);
            }
        }

        public void BuildTower(TowerType type)
        {
            foreach(SideTower tower in sideTowers)
            {
                if (tower.towerType == type) StartBuildTower(tower);
            }
        }

        private bool CheckArea()
        {
            print("Check area");
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
            

            foreach(Collider hit in hits)
            {
                if (hit.TryGetComponent(out BuildArea area))
                {
                    if(area.AreaType == BuildArea.Type.Inner)
                    {
                        print("Too close");
                        return false;
                    }
                       
                    if (area.AreaType == BuildArea.Type.Outer)
                    {
                        print("Nice spot");
                        return true;
                    }
                        
                }
            }
            print("Too far");
            return false;
        }

        private async void StartBuildTower(SideTower towerPrefab)
        {
            player.enabled = false;
            await UniTask.Delay(1000);
            Tower newTower = Instantiate(towerPrefab, transform.position, Quaternion.identity, TowerManager.Instance.transform);
            TowerManager.Instance.AddTower(newTower);
            await UniTask.Delay(1000);
            player.enabled = true;
        }

    }
}


