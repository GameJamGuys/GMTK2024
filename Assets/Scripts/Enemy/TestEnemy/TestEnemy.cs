using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class TestEnemy : BaseEnemy
    {
        protected override void Attack(List<Target> targets)
        {
            foreach (Target target in targets)
            {
                target.GetDamage(AttackDamage);
            }
        }
    }
}