using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class Book : MonoBehaviour
{
    
    private bool activar = true;
    private GameObject libro;

    public InputActionReference openBook;

    void Start()
    {
        libro = GameObject.FindWithTag("Libro").gameObject;
        libro.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void OpenBook(InputAction.CallbackContext callbackContext)
    {
        
        if (callbackContext.performed)
        {
            abrirLibro(activar);
        }
        
    }

    private void abrirLibro(bool n)
    {
        libro.SetActive(n);
        if (activar)
        {
            activar = false;
        }
        else
        {
            activar = true;
        }

    }
}


