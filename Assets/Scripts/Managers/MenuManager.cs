using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject mainMenu;
    public GameObject gameMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject creditsMenu;
    public GameObject gameOverMenu;
    public Button botonContinuar;
    public static string previousScene;
    public static bool openPauseMenu;
    public static bool returnToPause = false;
    private string savingArchive;
    public void ContinueGame()
    {
        string savingArchive = ControladorDatosJuego.Instance.savingArchive;

        if (File.Exists(savingArchive))
        {
            ControladorDatosJuego.Instance.isContinue = true;
            ControladorDatosJuego.Instance.LoadData();

            StartCoroutine(ChangeSceneAsync("SampleScene"));
        }
        else
        {
            Debug.Log("No hay partida guardada");
        }

    }
    public void ActivarBotonContinuar()
    {
        botonContinuar.interactable = true;
    }
    public void ChangeMainToGame()
    {
        ControladorDatosJuego.Instance.isContinue = false;
        ControladorDatosJuego.Instance.gameSettings = new GameSettings()
        {
            currentDay = 0,
            dinero = 0
        };
        ControladorDatosJuego.Instance.SaveData();
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
