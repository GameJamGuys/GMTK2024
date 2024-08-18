using System.Collections;
using System.Collections.Generic;
using BulletSystem;
using Enemy;
using UnityEngine;

namespace TowerSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class ShootingEffectTower : BaseEffectTower
    {
        [SerializeField] private Bullet BulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletAttackSpeed;
        [SerializeField] private float bulletDamage;

        private BaseEnemy targetEnemy;
        private List<BaseEnemy> enemiesInRange = new();

        private void Start()
        {
            StartCoroutine(UseEffectsCoroutine());
        }

        public override void UseEffect()
        {
            if (targetEnemy == null)
            {
                return;
            }
            Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;
            Instantiate(BulletPrefab, transform.position, Quaternion.identity).StartMove(bulletDamage, bulletSpeed, direction);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BaseEnemy enemy))
            {
                enemiesInRange.Add(enemy);

                TryChangeTarget(enemy);
            }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out BaseEnemy enemy))
            {
                enemiesInRange.Remove(enemy);

                TryChangeTarget();
            }
        }
        
        private void TryChangeTarget()
        {
            BaseEnemy potentialTarget = null;

            foreach (var baseEnemy in enemiesInRange)
            {
                if (potentialTarget == null || Vector3.Distance(baseEnemy.transform.position, transform.position) < Vector3.Distance(potentialTarget.transform.position, transform.position))
                {
                    potentialTarget = baseEnemy;
                }
            }

            targetEnemy = potentialTarget;
        }

        private void TryChangeTarget(BaseEnemy enemy)
        {

            if (targetEnemy == null || Vector3.Distance(enemy.transform.position, transform.position) < Vector3.Distance(targetEnemy.transform.position, transform.position))
            {
                targetEnemy = enemy;
            }
        }

        private IEnumerator UseEffectsCoroutine()
        {
            while (true)
            {
                UseEffect();
                yield return new WaitForSeconds(bulletAttackSpeed);
            }
        }
    }
}