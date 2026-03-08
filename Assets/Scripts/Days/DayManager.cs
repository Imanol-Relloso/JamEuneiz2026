using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [SerializeField] private int currentDay;

    [Header("PREFABS DE LOS DIAS")]
    [SerializeField] private Day[] days;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartDay()
    {
        if (currentDay < 0 || currentDay >= days.Length)
        {
            Debug.Log("No hay más días disponibles");
            return;
        }

        days[currentDay].InitializeDay();
    }

    public void NextDay()
    {
        currentDay++;
        StartDay();
    }

    public DayConditions GetDayConditions()
    {
        return GetCurrentDay().GetCoditions();
    }

    public Day GetCurrentDay()
    {
        return days[currentDay];
    }
}