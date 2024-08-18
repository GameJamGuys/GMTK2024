using System;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _scaleModifier;
    [SerializeField] private Health _health;

    private Dictionary<Resource.Types, int> _resources = new Dictionary<Resource.Types, int>();
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

        WalletData.SetAllData(1000);

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
            resource.Init(new Resource.ResourceInitData()
            {
                MoveTransform = transform,
                MoveForce = MoveForce,
                StartMoveDistance = StartMoveDistance,
                ScaleModifier = ScaleModifier
            });
        }
    }


    private void OnCollided(Resource resource)
    {
        int startValue = 1;

        switch (resource.Type)
        {
            case Resource.Types.Heal:
                _health.GetHeal();
                resource.TargetReach();
                return;
            default:   
                WalletData.AddResource(resource.Type, resource.Count);
                break;
        }

        if (_resources.ContainsKey(resource.Type))
        {
            int currentValue = _resources[resource.Type];
            currentValue++;
            _resources[resource.Type] = currentValue;
        }
        else
        {
            _resources.Add(resource.Type, startValue);
        }

        DisplayDictionary();
        resource.TargetReach();
    }

    private void DisplayDictionary()
    {
        Debug.Log("Dictionary:");

        foreach (Resource.Types resourceType in _resources.Keys)
        {
            Debug.Log($"{resourceType} : {_resources[resourceType]}");
        }
    }
}