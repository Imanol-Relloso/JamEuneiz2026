using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public DayManager dayManager;
    public CatBoatManager catBoatManager;
    public bool isContinue = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if(ControladorDatosJuego.Instance.isContinue)
        {
            ControladorDatosJuego.Instance.LoadData();
            DayManager.Instance.currentDay = ControladorDatosJuego.Instance.gameSettings.currentDay;
            CoinManger.Instance.dinero = ControladorDatosJuego.Instance.gameSettings.dinero;
        }
 
        StartDay();
        Debug.Log(CoinManger.Instance.dinero);
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
            CoinManger.Instance.SumarDinero();
        else
            DayManager.Instance.GetCurrentDay().errores++;

        NextBoat();
    }
}