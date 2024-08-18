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

    public Rigidbody Rigidbody { get; private set; }

    private Transform _moveTransform;
    private float _moveForce;
    private float _startMoveDist;
    private float _scaleModif;
    private bool _isInit = false;
    private bool _isMove = false;


    private void OnEnable()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(ResourceInitData data)
    {
        _moveTransform = data.MoveTransform;
        _moveForce = data.MoveForce;
        _startMoveDist = data.StartMoveDistance;
        _scaleModif = data.ScaleModifier;
        _isInit = true;
    }

    public void TargetReach()
    {
        Stop();
        Destroy(gameObject);
    }

    public void Stop()
    {
        _isMove = false;
        _isInit = false;
        Rigidbody.linearVelocity = Vector3.zero;
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
            Vector3 finalTarget = new Vector3(_moveTransform.position.x, _moveTransform.position.y + _offsetY,
                _moveTransform.position.z);

            //if (Vector3.Distance(finalTarget, transform.position) <= 1.2f)
            //{
            //    TargetReach();
            //    return;
            //}

            Vector3 direction = (finalTarget - transform.position).normalized;
            Rigidbody.linearVelocity = direction * _moveForce;
            
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
            float currentDistance = (_moveTransform.position - transform.position).magnitude;
            
            if (currentDistance <= _startMoveDist)
            {
                _isMove = true;
            }
        }
    }

    public struct ResourceInitData
    {
        public Transform MoveTransform;
        public float MoveForce;
        public float StartMoveDistance;
        public float ScaleModifier;
    }
}