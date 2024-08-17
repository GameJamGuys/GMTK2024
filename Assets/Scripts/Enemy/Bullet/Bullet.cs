using System;
using System.Collections;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class Bullet : MonoBehaviour
    {
        private float damage;
        private float speed;
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void StartMove(float damage, float speed, Vector3 targetPosition)
        {
            this.damage = damage;
            this.speed = speed;
            StartCoroutine(MoveCoroutine(targetPosition));
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Target target))    
            {
                target.GetDamage(damage);
            }
        }

        protected virtual IEnumerator MoveCoroutine(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - transform.position).normalized * speed;
            rigidbody.linearVelocity = direction;
            yield return null;
        }
    }
}