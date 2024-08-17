using System.Collections.Generic;
using Damage;

namespace Enemy
{
    public class CrabEnemy : BaseEnemy
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