using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class Book : MonoBehaviour
{
    
    private bool activar = true;
    private GameObject libro;

    public InputActionReference openBook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        libro = GameObject.FindWithTag("Libro").gameObject;
        libro.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            abrirLibro(activar);
        }*/
    }


    public void OpenBook(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            Debug.Log("Abrir libro");

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


