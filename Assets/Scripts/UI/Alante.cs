using UnityEngine;

using System.Collections;
public class Alante : MonoBehaviour
{
    [SerializeField] private bool alante;
    private Paginas paginas;

    void Start()
    {
        paginas = transform.parent.GetComponent<Paginas>();
    }

    void OnMouseDown()
    {
        paginas.CambiarPagina(alante);
    }
}
