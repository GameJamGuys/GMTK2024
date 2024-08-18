using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private uint _healAmount;

    private float _current;

    public event Action<float> HealthChanged;

    public event Action Died;

    public bool IsDead => _current <= 0;

    private void OnEnable()
    {
        _current = _max;
        HealthChanged?.Invoke(_current);
        //GetDamage(4);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown((KeyCode.O))) GetDamage(5);
        if(Input.GetKeyDown((KeyCode.P))) GetHeal();
    }


    public void GetDamage(uint damage)
    {
        _current -= damage;
        //Debug.Log($"Health: {_current}");
        HealthChanged?.Invoke(_current);

        if (IsDead)
        {
            Died?.Invoke();
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