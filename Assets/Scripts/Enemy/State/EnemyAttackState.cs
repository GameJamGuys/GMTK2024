using Core.StateMachine.States;
using Enemy;

public class EnemyAttackState : IStateWithArguments<BaseEnemy>
{
    private BaseEnemy enemy;
    public void Enter(BaseEnemy enemy)
    {
        this.enemy = enemy;
        enemy.StartAttacking();
    }

    public void Exit()
    {
        enemy.EndAttacking();
    }
}