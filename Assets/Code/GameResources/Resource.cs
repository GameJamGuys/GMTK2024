using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour
{
    private readonly float _offsetY = 1.5f;

    public enum Types
    {
        Attack,
        Support,
        Build,
        Heal,
        Note
    }

    public Types Type;

    private Rigidbody _rigidbody;

    private Transform _movePos;
    private float _moveForce;
    private float _startMoveDist;
    private float _scaleModif;
    private bool _isInit = false;
    private bool _isMove = false;


    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Harvester harvester)
    {
        _movePos = harvester.transform;
        _moveForce = harvester.MoveForce;
        _startMoveDist = harvester.StartMoveDistance;
        _scaleModif = harvester.ScaleModifier;
        _isInit = true;
    }

    public void TargetReach()
    {
        _isMove = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ColliderEventHandler player))
        {
            print("Collide with player");
            player.Collided?.Invoke(this);
        }
    }

    private void FixedUpdate()
    {
        if(_isMove)
        {
            Vector3 finalTarget = new Vector3(_movePos.position.x, _movePos.position.y + _offsetY,
                _movePos.position.z);

            //if (Vector3.Distance(finalTarget, transform.position) <= 1.2f)
            //{
            //    TargetReach();
            //    return;
            //}

            Vector3 direction = (finalTarget - transform.position).normalized;
            _rigidbody.linearVelocity = direction * _moveForce;
            
            float scale = transform.localScale.x - _scaleModif;
            if (scale <= 0.1f)
            {
                scale = 0.1f;
            }
            transform.localScale = new Vector3(scale, scale, scale);

            return;
        }

        if (_isInit)
        {
            float currentDistance = (_movePos.position - transform.position).magnitude;
            
            if (currentDistance <= _startMoveDist)
            {
                _isMove = true;
            }
        }
    }

}