using System.Collections.Generic;
using BulletSystem;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class BaseRangeEnemy : BaseEnemy
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float attackRadius;

        protected override void Awake()
        {
            base.Awake();
            BaseEnemyAttack.SetAttackRadius(attackRadius);
        }

        protected override void Attack(List<Target> targets)
        {
            if (targets.Count == 0)
            {
                return;
            }
            
            Instantiate(bulletPrefab, transform.position, Quaternion.identity).StartMove(AttackDamage, bulletSpeed, targets[0].transform.position);
        }
    }
}