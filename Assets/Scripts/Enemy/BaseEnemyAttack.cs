using System;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class BaseEnemyAttack : MonoBehaviour
    {
        public event Action OnTargetCollision;
        
        public Target Target { get; private set; }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent( out Target damageable))
            {
                Target = damageable;
                OnTargetCollision?.Invoke();
            }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent( out Target damageable) && damageable == Target)
            {
                Target = null;
            }
        }
    }
}