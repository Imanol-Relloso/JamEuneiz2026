using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject seal;
    public Color changerColor;
    public int id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        SpriteRenderer sr = seal.GetComponent<SpriteRenderer>();
        sr.color = changerColor;
        if (sr.color == Color.red)
        {
            seal.GetComponent<DocumentManager>().id = 1;
        }
        else if (sr.color == Color.green)
        {
            seal.GetComponent<DocumentManager>().id = 2;

        }
        else
        {
            seal.GetComponent<DocumentManager>().id = 0;
        }

    }
}
