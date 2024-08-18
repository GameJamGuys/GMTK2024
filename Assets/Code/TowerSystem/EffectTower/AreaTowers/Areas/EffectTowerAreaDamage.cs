using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace TowerSystem
{
    public class EffectTowerAreaDamage: EffectTowerArea
    {
        private float damage;
        private HashSet<BaseEnemy> enemies = new();

        public void Init(float damage)
        {
            this.damage = damage;
            Drop();
        }

        public override void Drop()
        {
            enemies.Clear();
        }

        protected override void TriggerAction(Collider collider)
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