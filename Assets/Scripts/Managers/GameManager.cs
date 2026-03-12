using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public DayManager dayManager;
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
        dayManager.StartDay();
    }

    public void NextBoat()
    {
        catBoatManager.SpawnBoat();
    }

    public void NextDay()
    {
        dayManager.NextDay();
    }

    public void CorrectGuess()
    {
        if (dayManager.GetCurrentDay().tutorialDay)
        {
            StartCoroutine(dayManager.tutorial.CorrectBoat());
        }

        NextBoat();
    }

    public void IncorrectGuess()
    {
        if (dayManager.GetCurrentDay().tutorialDay)
        {
            StartCoroutine(dayManager.tutorial.WrongBoat());
        }

        NextBoat();
    }
}