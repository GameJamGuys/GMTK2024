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
                Vector3 randPos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-2, 2));
                Instantiate(config.ResourcePrefab, transform.position + randPos, Quaternion.identity).SetCount(config.ResourceCount);
            }
        }

        Destroy(gameObject);
    }
}
