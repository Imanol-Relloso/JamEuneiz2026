using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public MenuManager menuManager;
    public CatBoatManager catBoatManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartDay();
    }

    public void StartDay()
    {
        DayManager.Instance.StartDay();
        catBoatManager.spawnCatBoat();
    }

    public void NextBoat()
    {
        catBoatManager.spawnCatBoat();
    }

    public void nextDay()
    {
        DayManager.Instance.NextDay();
        StartDay();
    }

    public void CorrectGuess()
    {
        //Suma puntos
        NextBoat();
    }
    public void IncorrectGuess()
    {
        NextBoat();
    }
}
