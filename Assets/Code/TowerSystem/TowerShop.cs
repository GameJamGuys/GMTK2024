using UnityEngine;

namespace TowerSystem
{
    public class TowerShop : MonoBehaviour
    {
        public void BuildRange() => BuildTower(TowerType.Range);
        public void BuildMelee() => BuildTower(TowerType.Melee);
        public void BuildSupport() => BuildTower(TowerType.Support);
        public void BuildMagnet() => BuildTower(TowerType.Magnet);

        public void BuildTower(TowerType type)
        {

        }
    }

}
