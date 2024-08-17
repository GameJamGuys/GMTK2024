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

        public void Spawn()
        {
            var position = points[Random.Range(0, points.Count)].position;
            position.y = 1;
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], position, Quaternion.identity);
            enemy.SetDefaultTarget(mainTowerTarget);
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
    }
}