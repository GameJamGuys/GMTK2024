using System;
using System.Collections;
using System.Collections.Generic;
using Damage;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        [field:SerializeField] public float Health {get; protected set;}
        [field:SerializeField] public float Speed {get; protected set;}
        [field:SerializeField] public float AttackSpeed {get; protected set;}
        [field:SerializeField] public float AttackDamage {get; protected set;}
        [field:SerializeField] public bool IsChasingGamer {get; protected set;}
        [field:SerializeField] public float AgroRange {get; protected set;}
        
        [field:SerializeField] public List<EnemyResourcesConfig> EnemyResourcesConfigs {get; protected set;}

        public float CurrentHealth {get; protected set;}
        public event Action<BaseEnemy> OnDie;
        
        protected BaseEnemyAttack BaseEnemyAttack;
        protected BaseEnemyTargets BaseEnemyTargets;

        protected EnemyStateMachine StateMachine;
        // todo заменить на позицию башни
        protected Rigidbody Rigidbody;

        protected virtual void Attack(List<Target> targets)
        {
            foreach (Target target in targets)
            {
                target.GetDamage(AttackDamage);
            }
        }
        
        private bool isMoving = false;
        private bool isAttacking = false;
        private Target chaisingTarget;
        

        protected virtual void Awake()
        {
            CurrentHealth = Health;
            BaseEnemyAttack = GetComponentInChildren<BaseEnemyAttack>();
            BaseEnemyTargets = GetComponentInChildren<BaseEnemyTargets>();
            Rigidbody = GetComponent<Rigidbody>();
            StateMachine = new EnemyStateMachine();
            StateMachine.Init();
            StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
            BaseEnemyTargets.SetAttackRadius(AgroRange);
        }

        public void SpawnResources()
        {
            foreach (EnemyResourcesConfig config in EnemyResourcesConfigs)
            {
                if (config.Chance >= Random.Range(0, 1))
                {
                    Instantiate(config.ResourcePrefab, transform.position, Quaternion.identity).SetCount(config.ResourceCount);
                }
            }
        }

        public void GetDamage(float damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDie?.Invoke(this);
            }
        }

        private void OnEnable()
        {
            BaseEnemyAttack.OnTargetCollision += ChangeStateToAttack;
            BaseEnemyTargets.OnTargetEnter += TargetEnter;
            BaseEnemyTargets.OnTargetExit += TargetExit;
        }

        private void OnDisable()
        {
            BaseEnemyAttack.OnTargetCollision -= ChangeStateToAttack;
            BaseEnemyTargets.OnTargetEnter -= TargetEnter;
            BaseEnemyTargets.OnTargetExit -= TargetExit;
        }

        private void TargetEnter(Target target)
        {
            bool isGamer = target.TryGetComponent(out Gamer gamer);

            if (!IsChasingGamer && isGamer)
            {
                return;
            }

            if (isGamer)
            {
                chaisingTarget = target;
                StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
            }
        }

        private void TargetExit(Target target)
        {
            if (target == chaisingTarget)
            {
                if (BaseEnemyTargets.Targets.Count == 0)
                {
                    chaisingTarget = BaseEnemyTargets.DefaultTarget;
                }
                else
                {
                    chaisingTarget = BaseEnemyTargets.Targets[^1];
                    StateMachine.Enter<EnemyMovementState, BaseEnemy>(this);
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

        public void SetDefaultTarget(Target target)
        {
            chaisingTarget = target;
            BaseEnemyTargets.SetDefaultTarget(target);
        }

        private void ChangeStateToAttack(Target target)
        {
            if (!IsChasingGamer && target.TryGetComponent(out Gamer gamer))
            {
                return;
            }
            
            StateMachine.Enter<EnemyAttackState, BaseEnemy>(this);
        }

        private IEnumerator AttackCoroutine()
        {
            while (isAttacking)
            {
                yield return new WaitForSeconds(AttackSpeed);

                Attack(BaseEnemyAttack.Targets);

                if (BaseEnemyAttack.Targets.Count == 0)
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
                    var velocity = (chaisingTarget.transform.position - transform.position).normalized;
                    velocity.y = 0;
                    Rigidbody.linearVelocity = velocity * Speed;
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