using UnityEngine;
using System.Collections.Generic;

public class Day : MonoBehaviour
{
    [SerializeField] public bool tutorialDay;

    [Header("CONDICIONES DEL DIA")]
    [SerializeField] private Name[] notAllowedCat;
    [SerializeField] private Country[] notAllowedCountry;
    [SerializeField] private Load[] notAllowedLoad;

    [Header("BARCOS DEL DIA")]
    [SerializeField] private GameObject[] catBoatWithoutError;
    [SerializeField] private GameObject[] catBoatWithError;
    [SerializeField] private int boatsWithoutErrors;
    [SerializeField] private int boatsWithErrors;

    private List<GameObject> boatsQueue;
    private DayConditions dayConditions;

    public void InitializeDay()
    {
        SetConditios();
        GenerateQueue();
    }

    private void SetConditios()
    {
        if (dayConditions == null)
        {
            dayConditions = new DayConditions();

            foreach (Name n in notAllowedCat)
                dayConditions.AddCondition(n);
            foreach (Country c in notAllowedCountry)
                dayConditions.AddCondition(c);
            foreach (Load l in notAllowedLoad)
                dayConditions.AddCondition(l);
        }
    }

    private void GenerateQueue()
    {
        if(tutorialDay)
        {
            boatsQueue = new List<GameObject>(catBoatWithoutError);
            return;
        }

        boatsQueue = new List<GameObject>();

        for (int i = 0; i < boatsWithoutErrors; i++)
        {
            GameObject prefab = catBoatWithoutError[Random.Range(0, catBoatWithoutError.Length)];
            boatsQueue.Add(prefab);
        }

        for (int i = 0; i < boatsWithErrors; i++)
        {
            GameObject prefab = catBoatWithError[Random.Range(0, catBoatWithError.Length)];
            boatsQueue.Add(prefab);
        }

        for (int i = boatsQueue.Count - 1; i > 0; i--)
        {
            int random = Random.Range(0, i + 1);

            GameObject temp = boatsQueue[i];
            boatsQueue[i] = boatsQueue[random];
            boatsQueue[random] = temp;
        }
    }

    public GameObject GetNextBoat()
    {
        if (boatsQueue.Count == 0)
            return null;

        GameObject boat = boatsQueue[0];
        boatsQueue.RemoveAt(0);
        return boat;
    }
    public bool HasBoatsLeft()
    {
        return boatsQueue != null && boatsQueue.Count > 0;
    }

    public DayConditions GetCoditions()
    {
        return dayConditions;
    }
}
