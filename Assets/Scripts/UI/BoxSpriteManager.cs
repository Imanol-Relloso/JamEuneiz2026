using UnityEngine;
using UnityEngine.EventSystems;

public class BoxSpriteManager : MonoBehaviour
{
    private Sprite openBox;
    [SerializeField] private Sprite closeBox;
    private bool isOpen = false;
    private SpriteRenderer sr;

    [Range(1,3)]
    [SerializeField] int numerodecaja;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if(numerodecaja == 1)
            openBox = GetComponentInParent<CatBoat>().loadSystem.loadSprite1;
        else if(numerodecaja==2)
            openBox = GetComponentInParent<CatBoat>().loadSystem.loadSprite2;
        else
            openBox = GetComponentInParent<CatBoat>().loadSystem.loadSprite3;
    }

    void OnMouseDown()
    {
        AudioManager.Instance.PlayBox();
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
