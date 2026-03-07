using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    public DayConditions dayConditions = new DayConditions();

    [SerializeField] private int currentDay = 1;

    [Header("CONDICIONES DIA 1")]
    [SerializeField]private Name[] notAllowedCat1;
    [SerializeField]private Country[] notAllowedCountry1;
    [SerializeField]private Load[] notAllowedLoad1;
    [Header("CONDICIONES DIA 2")]
    [SerializeField]private Name[] notAllowedCat2;
    [SerializeField]private Country[] notAllowedCountry2;
    [SerializeField]private Load[] notAllowedLoad2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        GenerateDayConditions();
    }

    public void NextDay()
    {
        currentDay++;
        GenerateDayConditions();
    }

    void GenerateDayConditions()
    {
        dayConditions.ClearConditions();

        switch (currentDay)
        {
            case 1:
                foreach (Name n in notAllowedCat1)
                    dayConditions.AddCondition(n);
                foreach (Country c in notAllowedCountry1)
                    dayConditions.AddCondition(c);
                foreach (Load l in notAllowedLoad1)
                    dayConditions.AddCondition(l);
                break;

            case 2:
                foreach (Name n in notAllowedCat2)
                    dayConditions.AddCondition(n);
                foreach (Country c in notAllowedCountry2)
                    dayConditions.AddCondition(c);
                foreach (Load l in notAllowedLoad2)
                    dayConditions.AddCondition(l);
                break;
        }
    }
}
