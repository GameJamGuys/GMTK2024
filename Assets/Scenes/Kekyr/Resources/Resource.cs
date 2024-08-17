using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour
{
    private readonly float _offsetY = 1.5f;

    [SerializeField] private ResourceSO _data;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private Rigidbody _rigidbody;

    private Transform _movePos;
    private float _moveForce;
    private float _startMoveDist;
    private float _scaleModif;
    private bool _isInit = false;
    private bool _isMove = false;

    public ResourceSO Data => _data;

    private void OnEnable()
    {
        if (_data == null)
        {
            throw new ArgumentNullException(nameof(_data));
        }

        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer.sprite = _data.Image;
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

    private void FixedUpdate()
    {
        if(_isMove)
        {
            Vector3 finalTarget = new Vector3(_movePos.position.x, _movePos.position.y + _offsetY,
                _movePos.position.z);
            Vector3 direction = (finalTarget - transform.position).normalized;
            _rigidbody.linearVelocity = direction * _moveForce;
            
            float scale = transform.localScale.x - _scaleModif;
            if (scale <= 0)
            {
                scale = 0;
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