using UnityEngine;

namespace TowerSystem
{
    public class AreaHealEffectTower : AreaEffectTower<EffectTowerAreaHeal>
    {
        [SerializeField] private float areaHeal;

        protected override void Start()
        {
            base.Start(); 
            EffectTowerArea.Init(areaHeal); 
            UseEffect();
        }
    }
}