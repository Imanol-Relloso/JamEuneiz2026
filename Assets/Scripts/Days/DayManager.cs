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

    private void Start()
    {
        StartDay();
    }

    private void StartDay()
    {
        days[currentDay].InitializeDay();
    }

    public void NextDay()
    {
        currentDay++;

        StartDay();
    }

    public DayConditions GetDayConditions()
    {
        return days[currentDay].GetCoditions();
    }

    public Day GetCurrentDay()
    {
        return days[currentDay];
    }
}