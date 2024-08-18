using System.Collections;
using UnityEngine;

namespace TowerSystem
{
    public abstract class AreaEffectTower<T> : BaseEffectTower where T : EffectTowerArea
    {
        [SerializeField] private T effectTowerAreaPrefab;
        [SerializeField] private float areaScaleDuration;
        [SerializeField] private float areaMaxScale;
        [SerializeField] private float areaScaleCooldown;
        
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
                yield return StartCoroutine(ScaleAreaCoroutine());
                yield return new WaitForSeconds(areaScaleCooldown);
            }
        }

        private IEnumerator ScaleAreaCoroutine()
        {
            float time = 0;
            EffectTowerArea.transform.localScale = Vector3.zero;
            Vector3 endScale = Vector3.one * areaMaxScale;

            while (time < areaScaleDuration)
            {
                EffectTowerArea.transform.localScale = Vector3.Lerp(EffectTowerArea.transform.localScale, endScale, time / areaScaleDuration);
                time += Time.deltaTime;
                yield return null;
            }

            EffectTowerArea.transform.localScale = Vector3.zero;
            EffectTowerArea.Drop();
        }
    }
}