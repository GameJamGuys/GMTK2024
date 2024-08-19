using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace TowerSystem
{
    public class TowerBuilder : StaticInstance<TowerBuilder>
    {
        [SerializeField] Gamer player;
        [SerializeField] GnomeVisual visual;
        [Space]
        [SerializeField]
        List<SideTower> sideTowers;

        [Space]
        [SerializeField] GameObject hintClose, hintFar;


        public void BuildTower(TowerType type)
        {
            foreach(SideTower tower in sideTowers)
            {
                if (tower.towerType == type) StartBuildTower(tower);
            }
        }

        public bool CheckArea()
        {
            print("Check area");
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
            

            foreach(Collider hit in hits)
            {
                print(hit.name);
                if (hit.TryGetComponent(out BuildArea area))
                {
                    if(area.AreaType == BuildArea.Type.Inner)
                    {
                        print("Too close");
                        ShowAndClose(hintClose);
                        return false;
                    }
                }
            }

            foreach (Collider hit in hits)
            {
                print(hit.name);
                if (hit.TryGetComponent(out BuildArea area))
                {
                    if (area.AreaType == BuildArea.Type.Outer)
                    {
                        print("Nice spot");
                        return true;
                    }
                }
            }

            print("Too far");
            ShowAndClose(hintFar);
            return false;
        }

        public async void ShowAndClose(GameObject closeObject)
        {
            closeObject.SetActive(true);
            await UniTask.Delay(800);
            closeObject.SetActive(false);
        }

        private async void StartBuildTower(SideTower towerPrefab)
        {
            player.enabled = false;
            visual.StartBuild();
            await UniTask.Delay(1000);
            Tower newTower = Instantiate(towerPrefab, transform.position, Quaternion.identity, TowerManager.Instance.transform);
            TowerManager.Instance.AddTower(newTower);
            await UniTask.Delay(1000);
            player.enabled = true;
        }

    }
}


