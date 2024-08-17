using System;
using System.Collections;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private float damage;
        private float speed;

        public void StartMove(float damage, float speed, Vector3 targetPosition)
        {
            this.damage = damage;
            this.speed = speed;
            StartCoroutine(MoveCoroutine(targetPosition));
            StartCoroutine(DeathCoroutine());
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Target target))    
            {
                target.GetDamage(damage);
                Destroy(gameObject);
            }
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        protected virtual IEnumerator MoveCoroutine(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - transform.position).normalized * speed;
            direction.y = 0f;

            if (direction.x > 0 )
            {
                var rotation = spriteRenderer.transform.rotation;
                spriteRenderer.transform.rotation = new Quaternion(rotation.x, rotation.y, -rotation.z, rotation.w);
                spriteRenderer.flipX = true;
            }

            while (true)
            {
                transform.position += direction * Time.deltaTime * speed;
                yield return null;
            }
        }
    }
}