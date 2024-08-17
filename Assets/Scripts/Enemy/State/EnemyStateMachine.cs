using Core.StateMachine.States;

namespace Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public BaseEnemy Enemy { get; private set; }

        public void SetEnemy(BaseEnemy enemy)
        {
            Enemy = enemy;
        }

        public void Init()
        { 
            RegisterState(new EnemyAttackState());
            RegisterState(new EnemyMovementState());
        }
    }
}