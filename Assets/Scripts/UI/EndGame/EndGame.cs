using Enemy;
using TowerSystem;
using UnityEngine;

namespace UI.EndGame
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject loseImage;
        [SerializeField] private GameObject winImage;
        [SerializeField] private EnemiesWaveController enemiesWaveController;
        [SerializeField] private EnemySpawner enemySpawner;

        private bool isWavesEnded;

        private void Awake()
        {
            loseImage.SetActive(false);
            winImage.SetActive(false);
        }

        private void OnEnable()
        {
            TowerManager.Instance.OnMainTowerDie += Lose;
            enemiesWaveController.OnWavesEnded += WavesEnded;
        }

        private void OnDisable()
        {
            if (TowerManager.Instance)
            {
                TowerManager.Instance.OnMainTowerDie -= Lose;
            }
            
            enemiesWaveController.OnWavesEnded -= WavesEnded;
        }

        private void WavesEnded()
        {
            if (!enemySpawner.HasEnemies)
            {
                Win();
                return;
            }

            enemySpawner.OnEnemyDied += TryWin;
        }

        private void TryWin()
        {
            if (!enemySpawner.HasEnemies)
            {
                Win();
            }
        }

        private void Lose()
        {
            End();
            loseImage.SetActive(true);
        }
        
        private void Win()
        {
            End();
            winImage.SetActive(true);
        }

        private void End()
        {
            enemiesWaveController.StopWave();
            enemySpawner.DisableAllEnemies();
            PlayerInputRouter.Instance.DisableInputSystem();
        }
    }
}