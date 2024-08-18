using UnityEngine;
using System.Collections.Generic;
using Enemy;

public class Chest : MonoBehaviour
{
    [field: SerializeField] public List<EnemyResourcesConfig> EnemyResourcesConfigs { get; protected set; }

    private void OnTriggerEnter(Collider other)
    {
        print("Enter " + other.name);
        if (other.TryGetComponent(out Gamer gamer))
            SpawnResources();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void SpawnResources()
    {
        foreach (EnemyResourcesConfig config in EnemyResourcesConfigs)
        {
            if (config.Chance >= Random.Range(0, 1))
            {
                Instantiate(config.ResourcePrefab, transform.position, Quaternion.identity).SetCount(config.ResourceCount);
            }
        }

        Destroy(gameObject);
    }
}
