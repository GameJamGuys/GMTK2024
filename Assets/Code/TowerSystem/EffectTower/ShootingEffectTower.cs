using System.Collections;
using System.Collections.Generic;
using BulletSystem;
using Enemy;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
        
        private bool isReady;
        private float timer;

        private void Start()
        {
            isReady = true;
            timer = bulletAttackSpeed;
        }

        private void FixedUpdate()
        {
            if (isReady && targetEnemy != null)
                UseEffect();

            if(!isReady)
            {
                timer -= Time.fixedDeltaTime;
                if(timer <= 0)
                {
                    isReady = true;
                    timer = bulletAttackSpeed;
                }
            }
        }

        public override void UseEffect()
        {
            isReady = false;
            Instantiate(BulletPrefab, transform.position, Quaternion.identity).StartMove(bulletDamage, bulletSpeed, targetEnemy.transform.position);
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

    }
}