using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    public event Action OnGamePaused;
    public event Action OnGameUnpaused;

    private bool isGamePaused = false;

    public void LoadMenu() => Loader.Load(Loader.Scene.MainMenu);

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;

            OnGamePaused?.Invoke();
        }
        else
        {
            Time.timeScale = 1f;

            OnGameUnpaused?.Invoke();
        }
    }
}
