using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public MenuManager menuManager;
    public CatBoatManager catBoatManager;
    public GameObject coinManger;

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
    }

    public void NextBoat()
    {
        catBoatManager.spawnCatBoat();
    }

    public void nextDay()
    {
        DayManager.Instance.NextDay();
    }

    public void CorrectGuess()
    {
        //Suma puntos
        coinManger.GetComponent<CoinManger>().SumarDinero();
        NextBoat();
    }
    public void IncorrectGuess()
    {
        NextBoat();
    }
}
