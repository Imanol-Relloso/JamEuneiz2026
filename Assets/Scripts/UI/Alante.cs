using UnityEngine;

using System.Collections;
public class Alante : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        transform.parent.GetComponent<Paginas>().CambiarPagina(gameObject.name);
    }
}
