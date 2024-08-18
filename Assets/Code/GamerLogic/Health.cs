using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GnomeVisual _visual;
    [SerializeField] private float _max;
    [SerializeField] private uint _healAmount;

    private float _current;
    private Vector3 _spawnPosition;

    public event Action<float> HealthChanged;

    public event Action Died;

    public bool IsDead => _current <= 0;

    public float Max => _max;

    private void OnEnable()
    {
        if (_visual == null)
        {
            throw new ArgumentNullException(nameof(_visual));
        }

        _spawnPosition = transform.position;
        _current = _max;
        //HealthChanged?.Invoke(_current);
        //GetDamage(4);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown((KeyCode.O))) GetDamage(100);
        if(Input.GetKeyDown((KeyCode.P))) GetHeal();
    }


    public void GetDamage(uint damage)
    {
        _current -= damage;

        HealthChanged?.Invoke(_current);

        if (IsDead)
        {
            Died?.Invoke();
            gameObject.SetActive(false);
            _current = _max;
            transform.position = _spawnPosition;
            gameObject.SetActive(true);
        }
    }

    public void GetHeal()
    {
        if (_current + _healAmount <= _max)
        {
            _current += _healAmount;
            HealthChanged?.Invoke(_current);
        }
    }
}