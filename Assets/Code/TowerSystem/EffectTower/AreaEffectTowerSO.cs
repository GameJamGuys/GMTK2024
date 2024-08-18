using UnityEngine;

namespace TowerSystem
{
    public class AreaEffectTowerSO : EffectTowerConfigSO
    {
        [SerializeField] public float AreaScaleDuration;
        [SerializeField] public float AreaMaxScale;
        [SerializeField] public float AreaScaleCooldown;
        [SerializeField] public float AreaDamage;
        [SerializeField] public float AreaHeal;
        [SerializeField] public float BulletSpeed;
        [SerializeField] public float BulletAttackSpeed;
        [SerializeField] public float BulletDamage;
    }
}