using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private uint _start;
    [SerializeField] private uint _healAmount;

    private uint _current;

    public event Action<float> HealthChanged;

    public event Action Died;

    public bool IsDead => _current <= 0;

    private void OnEnable()
    {
        _current = _start;
        HealthChanged?.Invoke(_current);
        //GetDamage(4);
    }

    public void GetDamage(uint damage)
    {
        _current -= damage;
        Debug.Log($"Health: {_current}");
        HealthChanged?.Invoke(_current);

        if (IsDead)
        {
            Died?.Invoke();
        }
    }

    public void GetHeal()
    {
        if (_current + _healAmount <= _start)
        {
            _current += _healAmount;
            HealthChanged?.Invoke(_current);
        }
    }
}