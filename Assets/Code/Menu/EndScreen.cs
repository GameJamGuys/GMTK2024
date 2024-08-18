using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    private readonly float NewScale = 1f;
    private readonly float Duration = 1f;
    
    [SerializeField] private Image _win;
    [SerializeField] private Image _lose;

    [SerializeField] private Button _menu;
    [SerializeField] private Button _restart;

    private void Start()
    {
        if (_win == null)
        {
            throw new ArgumentNullException(nameof(_win));
        }

        if (_lose == null)
        {
            throw new ArgumentNullException(nameof(_lose));
        }

        if (_menu == null)
        {
            throw new ArgumentNullException(nameof(_menu));
        }

        if (_restart == null)
        {
            throw new ArgumentNullException(nameof(_restart));
        }
        
        _menu.onClick.AddListener(OnMenu);
        _restart.onClick.AddListener(OnRestart);
    }

    private void OnDisable()
    {
        _menu.onClick.RemoveListener(OnMenu);
        _restart.onClick.RemoveListener(OnRestart);
    }

    public void OnWin()
    {
        _win.gameObject.SetActive(true);
        OnEnd();
    }

    public void OnLose()
    {
        _lose.gameObject.SetActive(true);
        OnEnd();
    }
    
    public void OnMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

    public void OnRestart()
    {
        Loader.Load(Loader.Scene.Gameplay);
    }

    private void OnEnd()
    {
        _menu.transform.DOScale(NewScale, Duration);
        _restart.transform.DOScale(NewScale, Duration);
    }
}
