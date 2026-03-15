using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class Paginas : MonoBehaviour
{
    [SerializeField]private GameObject BotonAlante;
    [SerializeField]private GameObject BotonAtras;
    [SerializeField] private Sprite[] paginaQueCambia;
    [SerializeField] private Sprite[] paginasDeDias;
    [SerializeField] private Sprite[] paginasNormales;
    private List<Sprite> paginasP = new List<Sprite>();
    private SpriteRenderer sr;

    public int paginaactual = 1;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void ComprobarDia(int diaActual)
    {
        paginasP.Clear();

        paginasP.Add(paginaQueCambia[diaActual]);

        if (diaActual == 0)
            paginasP.Add(paginasDeDias[0]);
        else if (diaActual > 1)
        {
            paginasP.Add(paginasDeDias[1]);

            if (diaActual == 2)
                paginasP.Add(paginasDeDias[2]);
            else if (diaActual > 2)
            {
                paginasP.Add(paginasDeDias[3]);

                if (diaActual == 4)
                    paginasP.Add(paginasDeDias[4]);
                else if (diaActual > 4)
                {
                    paginasP.Add(paginasDeDias[5]);

                    if (diaActual == 6)
                        paginasP.Add(paginasDeDias[6]);
                }
            }
        }

        for (int i = 0; i < paginasNormales.Length; i++)
        {
            paginasP.Add(paginasNormales[i]);
        }

        paginaactual = 0;
        ActualizarSprite();
        ActualizarBotones();
    }

    public void CambiarPagina(bool accion)
    {
        if (!accion)
            paginaactual--;
        else
            paginaactual++;

        paginaactual = Mathf.Clamp(paginaactual, 0, paginasP.Count - 1);

        ActualizarSprite();
        ActualizarBotones();
    }
    void ActualizarSprite()
    {
        sr.sprite = paginasP[paginaactual];
    }

    void ActualizarBotones()
    {
        BotonAtras.SetActive(paginaactual > 0);
        BotonAlante.SetActive(paginaactual < paginasP.Count - 1);
    }
}
