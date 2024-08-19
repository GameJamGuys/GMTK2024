using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
    public class EnemiesWaveController : MonoBehaviour
    {
        [SerializeField] private EnemiesWavesSO wavesConfig;
        [SerializeField] private EnemySpawner enemySpawner;

        public event Action OnWavesEnded;
        
        private Coroutine coroutine;

        private async void Start()
        {
            await UniTask.Delay(200);
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
            foreach (Wave wave in wavesConfig.Waves)
            {
                foreach (WavePulse pulse in wave.Pulses)
                {
                    yield return new WaitForSeconds(pulse.PulseCooldown);

                    foreach (WavePulseEnemy wavePulseEnemy in pulse.Enemies)
                    {
                        for (int i = 0; i < wavePulseEnemy.Count; i++)
                        {
                            enemySpawner.Spawn(wavePulseEnemy.EnemyPrefab, enemySpawner.GetRandomSpawnPosition());
                        }
                    }
                }
            }
            OnWavesEnded?.Invoke();
        }
    }
}