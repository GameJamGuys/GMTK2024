using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _moveForce;
    
    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();
    [SerializeField]
    private ColliderEventHandler _colliderEventHandler;

    public float MoveForce => _moveForce;

    private void OnEnable()
    {
        _colliderEventHandler.Collided += OnCollided;
    }
    
    private void OnDisable()
    {
        _colliderEventHandler.Collided -= OnCollided;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Resource>(out Resource resource))
        {
            //Debug.Log("Staying");
            float currentDistance = (transform.position - resource.transform.position).magnitude;

            if (currentDistance <= _distance)
            {
                //Debug.Log("StartToMove");
                
                StartCoroutine(resource.MoveTo(this));
            }
        }
    }

    private void OnCollided(Resource resource)
    {
        int startValue = 1;

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

        DisplayDictionary();

        resource.gameObject.SetActive(false);
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
