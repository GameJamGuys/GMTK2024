using System;
using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class BaseEnemyAttack : MonoBehaviour
    {
        public event Action<Target> OnTargetCollision;

        public List<Target> Targets { get; private set; } = new();
        public CapsuleCollider Collider { get; private set; }

        private void Awake()
        {
            Collider = GetComponent<CapsuleCollider>();
        }

        public void SetAttackRadius(float radius)
        {
            if (Collider == null)
            {
                Collider = GetComponent<CapsuleCollider>();
            }

            Collider.radius = radius;
            Collider.height = radius;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent( out Target target) && !Targets.Contains(target))
            {
                Targets.Add(target);
                OnTargetCollision?.Invoke(target);
            }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent( out Target target) && Targets.Contains(target))
            {
                Targets.Remove(target);
            }
        }
    }
}