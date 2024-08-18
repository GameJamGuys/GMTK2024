using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerSystem
{
    public class EffectTowerAreaMagnet : EffectTowerArea
    {
        [SerializeField] private float resourceStopDistance;
        [SerializeField] private float resourceSpeed;

        private HashSet<Resource> resources = new();

        public void Init()
        {
            Drop();
        }

        public override void Drop()
        {
            resources.Clear();
        }

        private void Update()
        {
            foreach (Resource resource in resources.ToList())
            {
                if(ResourceIsNear(resource))
                {
                    resources.Remove(resource);
                    resource.Stop();
                }
            }
        }

        protected override void TriggerAction(Collider collider)
        {
            if (collider.TryGetComponent(out Resource resource))
            {
                if (resources.Contains(resource) || ResourceIsNear(resource))
                {
                    return;
                }

                resource.StartCoroutine(ResourceMoveCoroutine(resource));
                resources.Add(resource);
            }
        }

        private bool ResourceIsNear(Resource resource)
        {
            return Vector3.Distance(transform.position, resource.transform.position) < resourceStopDistance;
        }

        private IEnumerator ResourceMoveCoroutine(Resource resource)
        {
            Vector3 direction = (transform.position - resource.transform.position).normalized * resourceSpeed;

            while (!ResourceIsNear(resource))
            {
                resource.Rigidbody.linearVelocity = direction;
                yield return null;
            }
            
            resource.Rigidbody.linearVelocity = Vector3.zero;
        }
    }
}