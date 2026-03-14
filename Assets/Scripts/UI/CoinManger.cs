using UnityEngine;
using TMPro;

public class CoinManger : MonoBehaviour
{
    public static CoinManger Instance;
    public int dinero = 0;
    private TextMeshProUGUI texto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SumarDinero()
    {
        dinero += 10;

    }
}
