using Enemy;
using UnityEngine;

namespace BulletSystem
{
    public class PlayerBullet : Bullet
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BaseEnemy target))    
            {
                target.GetDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}