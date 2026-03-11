using UnityEngine;
using TMPro;

public class CoinManger : MonoBehaviour
{

    private int dinero = 0;
    private TextMeshProUGUI texto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        for(int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizarMarcador()
    {
        texto.text = "X" + dinero.ToString();
    }

    public void SumerDiner(int sumar)
    {
        dinero += sumar;
        ActualizarMarcador();
    }

    public void RestartDinero()
    {
        dinero = 0;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
        ActualizarMarcador();
    }
}
