using UnityEngine;

namespace Damage
{
    public abstract class Target : MonoBehaviour
    {
        public abstract void GetDamage(float damage);
    }
}