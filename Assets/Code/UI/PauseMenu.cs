using UnityEngine;
using UnityEngine.UI;
using System;
using TowerSystem;

public class PauseMenu : MonoBehaviour
{
    public event Action OnGamePaused;
    public event Action OnGameUnpaused;

    private bool isGamePaused = false;

    public void LoadMenu() => Loader.Load(Loader.Scene.MainMenu);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            TowerShop.Instance.OpenShop();
    }

    public void SetResume()
    {
        isGamePaused = true;
        TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        print("Game pause " + isGamePaused);
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
