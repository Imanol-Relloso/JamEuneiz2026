using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [SerializeField] private int currentDay;

    [Header("PREFABS DE LOS DIAS")]
    [SerializeField]private Day[] days;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void NextDay()
    {
        currentDay++;

        if (currentDay > days.Length)
            //se llama al final del juego
            return;
    }

    public DayConditions GetDayConditions()
    {
        return days[currentDay].GetCoditions();
    }
}
