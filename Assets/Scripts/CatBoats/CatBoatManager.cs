using UnityEngine;

public class CatBoatManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private GameObject currentCatBoat;

    public void spawnCatBoat()
    {
        Day currentDay = DayManager.Instance.GetCurrentDay();

        if (currentDay == null || !currentDay.HasBoatsLeft())
        {
            GameManager.Instance.nextDay();
            return;
        }

        if (currentCatBoat != null)
            Destroy(currentCatBoat);

        GameObject prefab = currentDay.GetNextBoat();

        currentCatBoat = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}