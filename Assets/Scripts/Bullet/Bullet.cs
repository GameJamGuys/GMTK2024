using System.Collections;
using Damage;
using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        protected float Damage;
        protected float Speed;

        public void StartMove(float damage, float speed, Vector3 targetPosition)
        {
            Damage = damage;
            Speed = speed;
            StartCoroutine(MoveCoroutine(targetPosition));
            StartCoroutine(DeathCoroutine());
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Target target))    
            {
                target.GetDamage(Damage);
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
            Vector3 direction = (targetPosition - transform.position).normalized * Speed;
            direction.y = 0f;

            if (direction.x > 0 )
            {
                var rotation = spriteRenderer.transform.rotation;
                spriteRenderer.transform.rotation = new Quaternion(rotation.x, rotation.y, -rotation.z, rotation.w);
                spriteRenderer.flipX = true;
            }

            while (true)
            {
                transform.position += direction * Time.deltaTime * Speed;
                yield return null;
            }
        }
    }
}