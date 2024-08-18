using UnityEngine;

namespace TowerSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public abstract class EffectTowerArea : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            TriggerAction(collider);
        }

        protected abstract void TriggerAction(Collider collider);
        public abstract void Drop();
    }
}