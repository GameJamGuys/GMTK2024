using System;
using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class BaseEnemyAttack : MonoBehaviour
    {
        public event Action OnTargetCollision;

        public List<Target> Targets { get; private set; } = new();

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent( out Target target) && !Targets.Contains(target))
            {
                Targets.Add(target);
                OnTargetCollision?.Invoke();
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