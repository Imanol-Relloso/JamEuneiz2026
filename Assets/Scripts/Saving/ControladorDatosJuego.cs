using UnityEngine;
using System.IO;
public class ControladorDatosJuego : MonoBehaviour
{
    public string savingArchive;
    public GameSettings gameSettings = new GameSettings();

    private void Awake()
    {
        savingArchive = Application.dataPath + "/gameSettings.json";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
        }
        if(Input.GetKey(KeyCode.C))
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (File.Exists(savingArchive))
        {
            string content = File.ReadAllText(savingArchive);
            gameSettings = JsonUtility.FromJson<GameSettings>(content);

            DayManager.Instance.currentDay = gameSettings.currentDay;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    private void SaveData()
    {
        Debug.Log("Guardo !");

        GameSettings newData = new GameSettings()
        {
            currentDay = DayManager.Instance.currentDay,
        };

        string cadenaJSON = JsonUtility.ToJson(newData);
        File.WriteAllText(savingArchive, cadenaJSON);

    }
}
