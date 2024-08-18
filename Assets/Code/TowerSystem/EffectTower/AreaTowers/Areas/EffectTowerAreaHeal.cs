using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    public class EffectTowerAreaHeal : EffectTowerArea
    {
        private float heal;
        private HashSet<Tower> towers = new();

        public void Init(float heal)
        {
            this.heal = heal;
            Drop();
        }

        public override void Drop()
        {
            towers.Clear();
        }

        protected override void TriggerAction(Collider collider)
        {
            if (collider.TryGetComponent(out Tower tower))
            {
                if (towers.Contains(tower))
                {
                    return;
                }

                tower.GetHeal(heal);
                towers.Add(tower);
            }
        }
    }
}