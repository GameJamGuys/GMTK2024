    using UnityEngine;

namespace TowerSystem
{
    public class AreaDamageEffectTower : AreaEffectTower<EffectTowerAreaDamage>
    {
        protected override void Start()
        {
           base.Start(); 
           EffectTowerArea.Init(Config.AreaDamage); 
           UseEffect();
        }
    }
}