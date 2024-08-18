using Damage;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : Target
    {
        public override void GetDamage(float damage)
        {
            Debug.Log("Tower GetDamage");
        }

        public void GetHeal(float heal)
        {
            Debug.Log("Tower GetHeal");
        }
    }
}