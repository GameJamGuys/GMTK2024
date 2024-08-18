using System.Collections.Generic;
using System.Linq;
using Damage;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Target mainTowerTarget;
        [SerializeField] private List<BaseEnemy> enemyPrefabs;

        private List<BaseEnemy> enemies = new();
        private List<Transform> points;

        private void Awake()
        {
            points = GetComponentsInChildren<Transform>().ToList();
        }

        private void Spawn()
        {
            Spawn(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], GetRandomSpawnPosition());
        }

        public Vector3 GetRandomSpawnPosition()
        {
            var position = points[Random.Range(0, points.Count)].position;
            position.y = 0.3f;
            return position;
        }

        public void Spawn(BaseEnemy enemyPrefab, Vector3 position)
        {
            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.SetDefaultTarget(mainTowerTarget);
            enemy.OnDie += EnemyDied;
            enemies.Add(enemy);
        }

        private void Update()
        {
            // todo для теста
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Spawn();
            }
        }

        private void EnemyDied(BaseEnemy enemy)
        {
            enemy.OnDie -= EnemyDied;
            enemy.SpawnResources();
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
}