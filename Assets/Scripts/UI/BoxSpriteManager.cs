using UnityEngine;
using UnityEngine.EventSystems;

public class BoxSpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite openBox;
    [SerializeField] private Sprite closeBox;
    private bool isOpen = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (isOpen)
        {
            sr.sprite = closeBox;
            isOpen = false;
        }
        else
        {
            sr.sprite = openBox;
            isOpen = true;
        }
    }
}
