using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BoatSpriteManager : MonoBehaviour, IPointerDownHandler
{
    public bool isBoatActive = true;
    public Collider2D colliderBarco;
    [SerializeField] private GameObject boat, deck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBoatActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (isBoatActive)
        {
            colliderBarco.enabled = false;
            boat.SetActive(false);
            deck.SetActive(true);
            isBoatActive = false;
        }
        else
        {
            colliderBarco.enabled = true;
            boat.SetActive(true);
            deck.SetActive(false);
            isBoatActive = true;
        }
    }
}
