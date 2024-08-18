using UnityEngine;

namespace TowerSystem
{
    public abstract class BaseEffectTower : MonoBehaviour
    {
        [SerializeField]
        protected AreaEffectTowerSO Config;
        
        public abstract void UseEffect();

        public virtual void ChangeConfig(AreaEffectTowerSO config)
        {
            Config = config;
        }
    }
}