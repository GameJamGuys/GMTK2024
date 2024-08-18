using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace TowerSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class AreaDamage: MonoBehaviour
    {
        private float damage;
        private HashSet<BaseEnemy> enemies = new();

        public void Init(float damage)
        {
            this.damage = damage;
            Drop();
        }

        public void Drop()
        {
            enemies.Clear();
            enemies = new();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BaseEnemy enemy))
            {
                if (enemies.Contains(enemy))
                {
                    return;
                }

                enemy.GetDamage(damage);
                enemies.Add(enemy);
            }
        }
    }
}