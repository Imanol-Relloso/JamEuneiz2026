using UnityEngine;

public class CatBoatManager : MonoBehaviour
{
    public static CatBoatManager instance; 

    [SerializeField] private Transform spawnPoint;

    public GameObject currentBoat;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void SpawnBoat()
    {
        Day currentDay = DayManager.Instance.GetCurrentDay();

        if (!currentDay.HasBoatsLeft())
        {
            ClearBoat();
            GameManager.Instance.NextDay();
            return;
        }

        ClearBoat();

        GameObject prefab = currentDay.GetNextBoat();

        currentBoat = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    private void ClearBoat()
    {
        if (currentBoat != null)
            Destroy(currentBoat);
    }
}