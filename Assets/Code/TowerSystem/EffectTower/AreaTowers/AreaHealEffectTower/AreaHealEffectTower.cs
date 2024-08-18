using UnityEngine;

namespace TowerSystem
{
    public class AreaHealEffectTower : AreaEffectTower<EffectTowerAreaHeal>
    {
        protected override void Start()
        {
            base.Start(); 
            EffectTowerArea.Init(Config.AreaHeal); 
            UseEffect();
        }
    }
}