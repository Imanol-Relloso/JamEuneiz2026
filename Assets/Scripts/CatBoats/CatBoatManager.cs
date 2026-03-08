using UnityEngine;

public class CatBoatManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private GameObject currentCatBoat;

    private void Start()
    {
        spawnCatBoat();
    }

    public void spawnCatBoat()
    {
        if (currentCatBoat != null)
            Destroy(currentCatBoat);

        Day day = DayManager.Instance.GetCurrentDay();

        if (!day.HasBoatsLeft())
        {
            //Final del dia
            Debug.Log("Fin del día");
            return;
        }

        GameObject prefab = day.GetNextBoat();

        currentCatBoat = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}