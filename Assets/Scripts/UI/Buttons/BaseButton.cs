using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        protected Button Button;

        private void Awake()
        {
            Button = GetComponent<Button>();
        }
        
        private void OnEnable()
        {
            Button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            Button.onClick.AddListener(OnClick);
        }

        public abstract void OnClick();
    }
}