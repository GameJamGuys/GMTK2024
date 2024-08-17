using System;
using System.Collections.Generic;
using Damage;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class BaseEnemyTargets : MonoBehaviour
    {
        public event Action<Target> OnTargetEnter;
        public event Action<Target> OnTargetExit;
        
        public List<Target> Targets { get; private set; } = new ();
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out Target target))
            {
                Debug.Log(collider.gameObject.name);
                if (!Targets.Contains(target))
                {
                    Targets.Add(target);
                    OnTargetEnter?.Invoke(target);
                }
            }
        }
        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out Target target))
            {
                Targets.Remove(target);
                OnTargetExit?.Invoke(target);
            }
        }
    }
}