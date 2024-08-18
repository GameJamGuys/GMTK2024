using System;
using UnityEngine;

public class ColliderEventHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    public Action<Resource> Collided;

    private void OnEnable()
    {
        if (_health == null)
        {
            throw new ArgumentNullException(nameof(_health));
        }
    }

}
