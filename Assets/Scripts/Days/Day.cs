using UnityEngine;
using System.Collections.Generic;

public class Day : MonoBehaviour
{
    [Header("CONDICIONES DEL DIA")]
    [SerializeField] private Name[] notAllowedCat;
    [SerializeField] private Country[] notAllowedCountry;
    [SerializeField] private Load[] notAllowedLoad;

    [Header("BARCOS DEL DIA")]
    [SerializeField] private GameObject[] catBoatPrefabs;
    [SerializeField] private int boatsQuantity;

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
        boatsQueue = new List<GameObject>();

        List<GameObject> tempList = new List<GameObject>(catBoatPrefabs);
        
        for (int i = tempList.Count - 1; i > 0; i--)
        {
            int random = Random.Range(0, i + 1);
            GameObject temp = tempList[i];
            tempList[i] = tempList[random];
            tempList[random] = temp;
        }

        for (int i = 0; i < boatsQuantity && i < tempList.Count; i++)
        {
            boatsQueue.Add(tempList[i]);
        }
    }

    public GameObject GetNextBoat()
    {
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
