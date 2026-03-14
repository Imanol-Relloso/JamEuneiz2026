using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject mainMenu;
    public GameObject gameMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject creditsMenu;
    public GameObject gameOverMenu;

    public static string previousScene;
    public static bool openPauseMenu;
    public static bool returnToPause = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
        StartCoroutine(LoadOptions());
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
        previousScene = "MainMenu";
        StartCoroutine(LoadOptions());
    }
    public void ChangeSettingsBack()
    {
        StartCoroutine(CloseOptionsAndRestore());
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    private IEnumerator CloseOptionsAndRestore()
    {
        if (previousScene == "SampleScene" && pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
        yield return StartCoroutine(CloseOptions());
    }
    private IEnumerator LoadOptions()
    {
        if (SceneManager.GetSceneByName("Options").isLoaded)
        {
            yield break;
        }
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }
    private IEnumerator CloseOptions()
    {
        if (!SceneManager.GetSceneByName("Options").isLoaded)
        {
            yield break;
        }
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync("Options");
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
