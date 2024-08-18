using System.Collections;
using UnityEngine;

namespace TowerSystem
{
    public class AreaDamageEffectTower : BaseEffectTower
    {
        [SerializeField] private AreaDamage areaPrefab;
        [SerializeField] private float areaScaleDuration;
        [SerializeField] private float areaMaxScale;
        [SerializeField] private float areaScaleCooldown;
        [SerializeField] private float areaDamage;
        
        private AreaDamage area;

        private void Start()
        {
            area = Instantiate(areaPrefab, transform);
            area.Init(areaDamage);
            UseEffect();
        }

        private void OnDestroy()
        {
            if (area)
            {
                Destroy(area.gameObject);
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
                area.Drop();
                yield return new WaitForSeconds(areaScaleCooldown);
            }
        }

        private IEnumerator ScaleAreaCoroutine()
        {
            float time = 0;
            area.transform.localScale = Vector3.zero;
            Vector3 endScale = Vector3.one * areaMaxScale;

            while (time < areaScaleDuration)
            {
                area.transform.localScale = Vector3.Lerp(area.transform.localScale, endScale, time / areaScaleDuration);
                time += Time.deltaTime;
                yield return null;
            }

            area.transform.localScale = Vector3.zero;
            yield return null;
        }
    }
}