using UnityEngine;
using System.IO;
public class ControladorDatosJuego : MonoBehaviour
{
    public static ControladorDatosJuego Instance;
    public string savingArchive;
    public GameSettings gameSettings = new GameSettings();
    public bool isContinue = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savingArchive = Application.persistentDataPath + "/gameSettings.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
        }
    }

    public void LoadData()
    {
        if (File.Exists(savingArchive))
        {
            string content = File.ReadAllText(savingArchive);
            gameSettings = JsonUtility.FromJson<GameSettings>(content);

            DayManager.Instance.currentDay = gameSettings.currentDay;
            CoinManger.Instance.dinero = gameSettings.dinero;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    public void SaveData()
    {
        if (gameSettings == null)
        {
            Debug.LogWarning("No");
            return;
        }

        string json = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(savingArchive, json);
        Debug.Log("Guardado correcto en: " + savingArchive);
    }
}
