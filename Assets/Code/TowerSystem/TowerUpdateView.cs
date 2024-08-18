using System;
using System.Collections;
using UnityEngine;

namespace TowerSystem
{
    public class TowerUpdateView : MonoBehaviour
    {
        private const float durationScale = .4f; 
        private const float scaleMultiplier = 2f;
        private Vector3 hoverScale;
        private Vector3 defaultScale;

        private void Awake()
        {
            defaultScale = transform.localScale;
            hoverScale = transform.localScale * scaleMultiplier;
        }

        private bool isHover;
        public void Hover()
        {
            transform.localScale = hoverScale;
            // if (isHover)
            // {
            //     return;
            // }
            //
            // isHover = true;
            // StartCoroutine(EnableScaleCoroutine());
        }
        
        public void UnHover()
        {
            transform.localScale = defaultScale;
            // if (!isHover)
            // {
            //     return;
            // }
            //
            // isHover = false;
            // StartCoroutine(DisableScaleCoroutine());
        }

        private IEnumerator EnableScaleCoroutine()
        {
            yield return StartCoroutine(ScaleCoroutine(transform.localScale * scaleMultiplier, isHover));
        }
        
        private IEnumerator DisableScaleCoroutine()
        {
            yield return  StartCoroutine(ScaleCoroutine(transform.localScale / scaleMultiplier, !isHover));
        }

        private IEnumerator ScaleCoroutine(Vector3 endScale, bool check)
        {
            float time = 0;
            Vector3 startScale = transform.localScale;

            while (time < durationScale && check)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, time / durationScale);
                time += Time.deltaTime;
                yield return null;
            }
            
            transform.localScale = endScale;
        }
    }
}