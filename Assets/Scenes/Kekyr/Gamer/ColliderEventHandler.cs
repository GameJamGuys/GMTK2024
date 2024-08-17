using System;
using UnityEngine;

public class ColliderEventHandler : MonoBehaviour
{
    public Action<Resource> Collided;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Resource>(out Resource resource))
        {
            Debug.Log("Collided!");
            Collided?.Invoke(resource);
        }
    }
}
