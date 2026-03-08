using UnityEngine;

public class Paginas : MonoBehaviour
{
    public GameObject[] Botones;
    public GameObject[] paginas;
    public int paginaactual ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paginaactual = 0;
        Botones = new GameObject[this.transform.childCount];

        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i] = this.transform.GetChild(i).gameObject;
        }

        paginas = new GameObject[Botones[2].transform.childCount];

        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i] = Botones[2].transform.GetChild(i).gameObject;
        }
        ComprobarPagina();

    }

    public void CambiarPagina(string accion)
    {
        paginas[paginaactual].gameObject.SetActive(false);
        if(accion.ToLower() == "atras")
        {
            paginaactual--;
            ComprobarPagina();
        }
        else if (accion.ToLower() == "alante")
        {
            paginaactual++;
            ComprobarPagina();
        }

        paginas[paginaactual].gameObject.SetActive(true);

    }

    public void ComprobarPagina()
    {
        if (paginaactual == 0)
        {
            Botones[0].gameObject.SetActive(false);
            Botones[1].gameObject.SetActive(true);
        }
        else if (paginaactual == Botones[2].transform.childCount-1)
        {
            Botones[0].gameObject.SetActive(true);
            Botones[1].gameObject.SetActive(false);
        }
        else
        {
            Botones[0].gameObject.SetActive(true);
            Botones[1].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
