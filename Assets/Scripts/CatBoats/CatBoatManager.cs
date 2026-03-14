using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CatBoatManager : MonoBehaviour
{
    public static CatBoatManager instance; 

    [SerializeField] private Transform spawnPoint;

    public GameObject currentBoat;

    [Header("TRANSICION ENTRE BARCOS")]
    [SerializeField] private GameObject transitionCanvas;
    [SerializeField] private UnityEngine.UI.Image fadeImage;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private float fadeTime = 1f;
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

        StartCoroutine(spawningCatBoat(prefab));
    }

    private void ClearBoat()
    {
        if (currentBoat != null)
            Destroy(currentBoat);
    }

    private IEnumerator spawningCatBoat(GameObject prefab)
    {
        transitionCanvas.SetActive(true);
        dayText.gameObject.SetActive(false);

        yield return FadeTransition(0f,1f);

        AudioManager.Instance.PlayPupu();

        yield return new WaitForSeconds(2f);

        AudioManager.Instance.PlayDoor();

        currentBoat = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        yield return FadeTransition(1f,0f);

        dayText.gameObject.SetActive(true);
        transitionCanvas.SetActive(false);
    }

    private IEnumerator FadeTransition(float start, float end)
    {
        float t = 0;
        Color backColor = fadeImage.color;

        while (t < fadeTime)
        {
            float value = Mathf.Lerp(start, end, t / fadeTime);

            fadeImage.color = new Color(backColor.r, backColor.g, backColor.b, value);
            dayText.alpha = value;

            t += Time.deltaTime;
            yield return null;
        }
    }
}