using System.Collections;
using UnityEngine;

namespace TowerSystem
{
    public abstract class AreaEffectTower<T> : BaseEffectTower where T : EffectTowerArea
    {
        [SerializeField] private T effectTowerAreaPrefab;
        
        protected T EffectTowerArea;

        protected virtual void Start()
        {
            EffectTowerArea = Instantiate(effectTowerAreaPrefab, transform);
        }

        private void OnDestroy()
        {
            if (EffectTowerArea)
            {
                Destroy(EffectTowerArea.gameObject);
            }
        }

        public override void UseEffect()
        {
            StartCoroutine(AreaScaleCoroutine());
        }

        private IEnumerator AreaScaleCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Config.AreaScaleCooldown);
                yield return StartCoroutine(ScaleAreaCoroutine());
            }
        }

        private IEnumerator ScaleAreaCoroutine()
        {
            float time = 0;
            EffectTowerArea.transform.localScale = Vector3.zero;
            Vector3 endScale = Vector3.one * Config.AreaMaxScale;

            while (time < Config.AreaScaleDuration)
            {
                EffectTowerArea.transform.localScale = Vector3.Lerp(EffectTowerArea.transform.localScale, endScale, time / Config.AreaScaleDuration);
                time += Time.deltaTime;
                yield return null;
            }

            EffectTowerArea.transform.localScale = Vector3.zero;
            EffectTowerArea.Drop();
        }
    }
}