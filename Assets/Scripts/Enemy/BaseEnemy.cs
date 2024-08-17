using System.Collections;
using System.Collections.Generic;
using Damage;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        [field:SerializeField] public float Health {get; protected set;}
        [field:SerializeField] public float Speed {get; protected set;}
        [field:SerializeField] public float CheckTargetDistance {get; protected set;}
        [field:SerializeField] public float AttackSpeed {get; protected set;}
        [field:SerializeField] public float AttackDamage {get; protected set;}
        [field:SerializeField] public bool IsChasingGamer {get; protected set;}

        [SerializeField] public BaseEnemyAttack baseEnemyAttack;
        [SerializeField] public BaseEnemyTargets baseEnemyTargets;

        protected EnemyStateMachine StateMachine;
        // todo заменить на позицию башни
        protected Rigidbody Rigidbody;
        protected abstract void Attack(List<Target> targets);
        
        private bool isMoving = false;
        private bool isAttacking = false;
        private Target chaisingTarget;
        

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            StateMachine = new EnemyStateMachine();
            StateMachine.Init();
            StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
        }

        private void OnEnable()
        {
            baseEnemyAttack.OnTargetCollision += ChangeStateToAttack;
            baseEnemyTargets.OnTargetEnter += TargetEnter;
            baseEnemyTargets.OnTargetExit += TargetExit;
        }

        private void OnDisable()
        {
            baseEnemyAttack.OnTargetCollision -= ChangeStateToAttack;
            baseEnemyTargets.OnTargetEnter -= TargetEnter;
            baseEnemyTargets.OnTargetExit -= TargetExit;
        }

        private void TargetEnter(Target target)
        {
            bool isGamer = target.TryGetComponent(out Gamer gamer);
            if (IsChasingGamer)
            {
                if (isGamer)
                {
                    chaisingTarget = target;
                }

                if (chaisingTarget == null)
                {
                    chaisingTarget = target;
                }
            }
            else
            {
                if (!isGamer && chaisingTarget == null)
                {
                    chaisingTarget = target;
                }
            }
        }

        private void TargetExit(Target target)
        {
            if (target == chaisingTarget)
            {
                if (baseEnemyTargets.Targets.Count == 0)
                {
                    chaisingTarget = null;
                }
                else
                {
                    chaisingTarget = baseEnemyTargets.Targets[^1];
                }
            }
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

        public void StartAttacking()
        {
            isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }

        public void EndAttacking()
        {
            isAttacking = false;
        }

        private void ChangeStateToAttack()
        {
            StateMachine.Enter<EnemyAttackState, BaseEnemy>(this);
        }

        private IEnumerator AttackCoroutine()
        {
            while (isAttacking)
            {
                yield return new WaitForSeconds(AttackSpeed);

                Attack(baseEnemyAttack.Targets);

                if (baseEnemyAttack.Targets.Count == 0)
                {
                    StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
                }

                yield return null;
            }
        }

        private IEnumerator MoveCoroutine()
        {
            while (isMoving)
            {
                if (chaisingTarget != null)
                {
                    Rigidbody.linearVelocity = (chaisingTarget.transform.position - transform.position).normalized * Speed;
                }
                else
                {
                    Rigidbody.linearVelocity = Vector3.zero;
                }

                yield return null;
            }
        }
    }
}