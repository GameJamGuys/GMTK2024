using System.Collections;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        [field:SerializeField] public float Health {get; protected set;}
        [field:SerializeField] public float Speed {get; protected set;}
        [field:SerializeField] public float CheckTargetDistance {get; protected set;}

        protected EnemyStateMachine StateMachine;
        // todo заменить на позицию башни
        protected Vector3 TargetPosition = Vector3.zero;
        protected Rigidbody Rigidbody;
        
        private bool isMoving = false;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            StateMachine = new EnemyStateMachine();
            StateMachine.Init();
            StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
        }

        public void ChangeTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }

        public void StartMoveTarget()
        {
            isMoving = true;
            StartCoroutine(MoveCoroutine());
        }
        
        public void EndMoveTarget()
        {
            isMoving = false;
            Rigidbody.linearVelocity = Vector3.zero;
        }

        private IEnumerator MoveCoroutine()
        {
            while (isMoving)
            {
                Rigidbody.linearVelocity = (TargetPosition - transform.position).normalized * Speed;

                if (Vector3.Distance(transform.position, TargetPosition) < 0.5)
                {
                    StateMachine.Enter<EnemyAttackState, BaseEnemy>(this);
                    yield break;
                }

                yield return null;
            }
        }
    }
}