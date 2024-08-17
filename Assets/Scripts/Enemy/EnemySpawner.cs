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
        [SerializeField] private BaseEnemy enemyPrefab;

        private List<BaseEnemy> enemies = new();
        private List<Transform> points;

        private void Awake()
        {
            points = GetComponentsInChildren<Transform>().ToList();
        }

        public void Spawn()
        {
            var position = points[Random.Range(0, points.Count)].position;
            position.y = 2;
            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
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