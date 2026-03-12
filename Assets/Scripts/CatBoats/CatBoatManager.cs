using UnityEngine;

public class CatBoatManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private GameObject currentBoat;

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