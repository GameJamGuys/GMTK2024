using System;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _scaleModifier;
    [SerializeField] private Health _health;

    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();
    [SerializeField] private ColliderEventHandler _colliderEventHandler;

    public float MoveForce => _moveForce;
    public float StartMoveDistance => _distance;

    public float ScaleModifier => _scaleModifier;

    private void OnEnable()
    {
        if (_health == null)
        {
            throw new ArgumentNullException(nameof(_health));
        }

        _colliderEventHandler.Collided += OnCollided;
    }

    private void OnDisable()
    {
        _colliderEventHandler.Collided -= OnCollided;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Resource>(out Resource resource))
        {
            resource.Init(this);
            //Debug.Log("Staying");
            
        }
    }


    private void OnCollided(Resource resource)
    {
        int startValue = 1;

        if (resource.Data.Type == ResourceType.Heal)
        {
            Debug.Log("Collided with heal");
            _health.GetHeal();
            resource.TargetReach();
            return;
        }

        if (_resources.ContainsKey(resource.Data.Type))
        {
            int currentValue = _resources[resource.Data.Type];
            currentValue++;
            _resources[resource.Data.Type] = currentValue;
        }
        else
        {
            _resources.Add(resource.Data.Type, startValue);
        }

        //DisplayDictionary();
        resource.TargetReach();
    }

    private void DisplayDictionary()
    {
        Debug.Log("Dictionary:");

        foreach (ResourceType resourceType in _resources.Keys)
        {
            Debug.Log($"{resourceType} : {_resources[resourceType]}");
        }
    }
}