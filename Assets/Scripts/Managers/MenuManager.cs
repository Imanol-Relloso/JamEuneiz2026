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

    public static string previousScene;
    public static bool openPauseMenu = false;
    public static bool returnToPause = false;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (returnToPause && scene.name == "SampleScene")
        {
            pauseMenu.SetActive(true);
            returnToPause = false;
        }
    }

    public void ChangeMainToGame()
    {
        StartCoroutine(ChangeSceneAsync("SampleScene"));
    }
    public void ChangeGameToPause()
    {
        //gameMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void ChangePauseToGame()
    {
        pauseMenu.SetActive(false);
        //gameMenu.SetActive(true);
    }
    public void ChangePauseToSettings()
    {
        previousScene = "SampleScene";
        returnToPause = true;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        StartCoroutine(ChangeSceneAsync("Options"));
    }
    public void ChangePauseToMain()
    {
        StartCoroutine(ChangeSceneAsync("MainMenu"));
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
        openPauseMenu = false;
        previousScene = "MainMenu";
        StartCoroutine(ChangeSceneAsync("Options"));
    }
    public void ChangeSettingsBack()
    {
        StartCoroutine(ChangeSceneAsync(previousScene));
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
