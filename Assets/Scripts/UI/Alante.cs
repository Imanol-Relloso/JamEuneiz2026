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
        AudioManager.Instance.PlayLibreta();
        paginas.CambiarPagina(alante);
    }
}
