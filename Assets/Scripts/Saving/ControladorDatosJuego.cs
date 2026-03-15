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
            savingArchive = Application.dataPath + "/gameSettings.json";
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
        Debug.Log("Guardo !");

        GameSettings newData = new GameSettings()
        {
            currentDay = DayManager.Instance.currentDay,
            dinero = CoinManger.Instance.dinero,
        };

        string cadenaJSON = JsonUtility.ToJson(newData);
        File.WriteAllText(savingArchive, cadenaJSON);

    }
}
