using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class CucumberEnemy : BaseEnemy
    {
        [SerializeField] private Bullet bulletPrefab;

        protected override void Attack(List<Target> targets)
        {
            if (targets.Count == 0)
            {
                return;
            }
            
            Instantiate(bulletPrefab, transform.position, Quaternion.identity).StartMove(AttackDamage, 9f, targets[0].transform.position);
        }
    }
}