using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private readonly float NewScale = 1f;
    private readonly float Duration = 1f;
    //[SerializeField] private Button playButton;

    [SerializeField] private Button startButton;
    //[SerializeField] private Button quitButton;

    private void OnEnable()
    {
        startButton.transform.DOScale(NewScale, Duration);
    }
    private void Awake()
    {
        //playButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.Gameplay); });
        //quitButton.onClick.AddListener(() => { Application.Quit(); });
        startButton.onClick.AddListener(()=>{Loader.Load(Loader.Scene.CutScene);});

        Time.timeScale = 1f;
    }
}