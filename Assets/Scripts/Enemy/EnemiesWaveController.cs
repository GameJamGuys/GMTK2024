using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemiesWaveController : MonoBehaviour
    {
        [Header("Список волн")]
        [SerializeField] private List<Wave> waves;
        [SerializeField] private EnemySpawner enemySpawner;
        
        private Coroutine coroutine;

        private void Start()
        {
            StartWave();
        }

        public void StartWave()
        {
            coroutine = StartCoroutine(WaveCoroutine());
        }

        public void StopWave()
        {
            StopCoroutine(coroutine);
        }

        private IEnumerator WaveCoroutine()
        {
            foreach (Wave wave in waves)
            {
                foreach (WavePulse pulse in wave.Pulses)
                {
                    foreach (WavePulseEnemy wavePulseEnemy in pulse.Enemies)
                    {
                        for (int i = 0; i < wavePulseEnemy.Count; i++)
                        {
                            enemySpawner.Spawn(wavePulseEnemy.EnemyPrefab, enemySpawner.GetRandomSpawnPosition());
                        }
                    }
                    
                    yield return new WaitForSeconds(pulse.PulseCooldown);
                }
            }
        }
    }

    [Serializable]
    public class Wave
    {
        [Header("Пульс - это спавн группы врагов")]
        public List<WavePulse> Pulses = new ();
    }

    [Serializable]
    public class WavePulse
    {
        [Header("Перерыв до следующего пульса")]
        public float PulseCooldown;
        [Header("Список врагов с их количеством, которых надо заспавнить в этот пульс")]
        public List<WavePulseEnemy> Enemies = new ();
    }
    
    [Serializable]
    public class WavePulseEnemy
    {
        [Header("Префаб врага")]
        public BaseEnemy EnemyPrefab;
        [Header("Количество врагов для спавна")]
        public int Count;
    }
}