using Core.StateMachine.States;
using Damage;
using UnityEngine;

namespace Enemy
{
    public class TestEnemy : BaseEnemy
    {
        protected override void Attack(Target target)
        {
            Debug.Log("Attack");
        }
    }
}