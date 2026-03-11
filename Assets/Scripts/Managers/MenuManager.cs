using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject creditsMenu;
    public GameObject gameOverMenu;

    void Start()
    {
       
    }

    public void ChangeMainToGame()
    {
        StartCoroutine(ChangeSceneAsync("OliverPruebas"));
    }
    public void ChangeGameToPause()
    {
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);

    }
    public void ChangePauseToGame()
    {
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);
    }
    public void ChangeMainToCredits()
    {
        StartCoroutine(ChangeSceneAsync("Credits"));
    }
    public void ChangeCreditsToMain()
    {
        StartCoroutine(ChangeSceneAsync("MainMenu"));
    }
    public void ChangeGameToGameOver()
    {
        StartCoroutine(ChangeSceneAsync("GameOver"));
    }
    public void ChangeGameOverToMain()
    {
        StartCoroutine(ChangeSceneAsync("MainMenu"));
    }
    public void ChangeMainToSettings()
    {
        StartCoroutine(ChangeSceneAsync("Options"));
    }
    public void ChangeSettingToMain()
    {
        StartCoroutine(ChangeSceneAsync("MainMenu"));
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    private IEnumerator ChangeSceneAsync(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

    }
}
