using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject seal;
    public Color changerColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SpriteRenderer sr = seal.GetComponent<SpriteRenderer>();
        sr.color = changerColor;

    }
}
