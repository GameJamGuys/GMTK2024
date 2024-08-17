using Core.StateMachine.States;
using Enemy;
using UnityEngine;

public class EnemyMovementState : IStateWithArguments<BaseEnemy>
{
    private BaseEnemy enemy;
    public void Enter(BaseEnemy enemy)
    {
        this.enemy = enemy;
        this.enemy.StartMoveTarget();
    }

    public void Exit()
    {
        enemy.EndMoveTarget();
    }
}