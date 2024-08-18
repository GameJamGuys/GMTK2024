using UnityEngine;

namespace TowerSystem
{
    public class AreaDamageEffectTower : AreaEffectTower<EffectTowerAreaDamage>
    {
        [SerializeField] private float areaDamage;

        protected override void Start()
        {
           base.Start(); 
           EffectTowerArea.Init(areaDamage); 
           UseEffect();
        }
    }
}