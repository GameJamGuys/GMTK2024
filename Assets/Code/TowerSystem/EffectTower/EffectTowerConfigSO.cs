using UnityEngine;

namespace TowerSystem
{
    public abstract class EffectTowerConfigSO : ScriptableObject
    {
        [SerializeField] public float Health;
    }
}