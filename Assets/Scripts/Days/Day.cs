using UnityEngine;

public class Day : MonoBehaviour
{
    [Header("CONDICIONES DEL DIA ")]
    [SerializeField] private Name[] notAllowedCat;
    [SerializeField] private Country[] notAllowedCountry;
    [SerializeField] private Load[] notAllowedLoad;

    private DayConditions dayConditions;
    public DayConditions GetCoditions()
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


        return dayConditions;
    }
}
