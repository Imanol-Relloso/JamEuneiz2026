using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public DayManager dayManager;
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
        dayManager.StartDay();
    }

    public void NextBoat()
    {
        catBoatManager.SpawnBoat();
    }

    public void NextDay()
    {
        StartCoroutine(dayManager.NextDay());
    }

    public IEnumerator Guess(bool correct)
    {
        if (dayManager.GetCurrentDay().tutorialDay)
        {
            if (correct)
                yield return StartCoroutine(dayManager.tutorial.CorrectBoat());
            else
                yield return StartCoroutine(dayManager.tutorial.WrongBoat());
        }

        if (correct)
            coinManger.GetComponent<CoinManger>().SumarDinero();

        NextBoat();
    }
}