using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class TestEnemy : BaseEnemy
    {
        protected override void Attack(List<Target> targets)
        {
            Debug.Log("Attack");
        }
    }
}