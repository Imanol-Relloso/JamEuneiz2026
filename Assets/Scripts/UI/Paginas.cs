using UnityEngine;
using System.Collections.Generic;

public class Paginas : MonoBehaviour
{
    private GameObject[] Botones;
    private List<GameObject> paginas;
    [SerializeField] private GameObject[] paginasPrefab;
    private List<GameObject> paginasP;

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


        

    }

   


    public void ComprobarDia()
    {
        string[] days = new string[4];
        days = DayManager.Instance.GetCurrentDay().ToString().Split(" ");
        int diaActual = int.Parse(days[1]);

        paginaactual = 0;
        Botones = new GameObject[this.transform.childCount];

        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i] = this.transform.GetChild(i).gameObject;
        }

        GameObject instanciaPaginas = Instantiate(paginasPrefab[diaActual]);
        Debug.Log(instanciaPaginas.transform.childCount+ " ");

        for (int j = 0; j < paginasPrefab[diaActual].transform.childCount; j++)
        {
            Debug.Log(instanciaPaginas.transform.GetChild(0).name + "23999 " + instanciaPaginas.transform.childCount + " aa " + paginasPrefab[diaActual].transform.childCount);

            instanciaPaginas.transform.GetChild(0).SetParent(Botones[2].transform, false);

        }

        paginas = new List<GameObject>();

        for (int i = 0; i < Botones[2].transform.childCount; i++)
        {
            paginas.Add(Botones[2].transform.GetChild(i).gameObject);
        }

        
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
