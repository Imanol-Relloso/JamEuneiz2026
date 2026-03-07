using UnityEngine;
using UnityEngine.EventSystems;

public class BoxSpriteManager : MonoBehaviour, IPointerDownHandler
{
    public Sprite openBox, closedBox;
    private SpriteRenderer spriteRenderer;
    public GameObject box;
    private bool isOpen = false;
   
    public void Start()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {  
        if (box!= isOpen)
        {
            box.GetComponent<SpriteRenderer>().sprite = openBox;
            isOpen = true;
        }
        else
        {
            box.GetComponent<SpriteRenderer>().sprite = closedBox;
            isOpen = false;
        }
    }
}
