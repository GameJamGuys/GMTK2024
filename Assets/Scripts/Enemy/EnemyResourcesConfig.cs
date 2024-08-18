using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyResourcesConfig
    {
        public Resource ResourcePrefab;
        public int ResourceCount;

        [Range(0, 1)]
        public float Chance;
    }
}