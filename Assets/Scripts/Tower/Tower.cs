using Damage;
using UnityEngine;

namespace Tower
{
    public class Tower : Target
    {
        public override void GetDamage(float damage)
        {
            Debug.Log("Tower GetDamage");
        }
    }
}