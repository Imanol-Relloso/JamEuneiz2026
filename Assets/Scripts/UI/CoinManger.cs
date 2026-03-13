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
    void Start()
    {
        texto = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ApagarEncender(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizarMarcador()
    {
        texto.text = "X" + dinero.ToString();
    }

    public void SumarDinero()
    {
        dinero += 10;

        ActualizarMarcador();
    }

    public void ApagarEncender(bool booleana)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(booleana);
        }
    }

    public void RestartDinero()
    {
        dinero = 0;
        ApagarEncender(true);
        ActualizarMarcador();
    }
}
