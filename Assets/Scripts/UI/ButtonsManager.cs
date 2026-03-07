using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsManager : MonoBehaviour, IPointerDownHandler
{
    private RectTransform rectTrans; // Es como el transform pero un rectángulo para poder poner los sellos en el sitio
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    private bool isShowing = false;
    [SerializeField] private GameObject boat, documentDisplayed, document, door, redSeal, greenSeal, seal;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isShowing)
        {
            boat.SetActive(false);
            documentDisplayed.SetActive(true);
            document.SetActive(false);
            redSeal.SetActive(true);
            greenSeal.SetActive(true);
            seal.SetActive(true);
            door.SetActive(true);
            isShowing = true;
        }
        else
        {
            boat.SetActive(true);
            documentDisplayed.SetActive(false);
            document.SetActive(true);
            redSeal.SetActive(false);
            greenSeal.SetActive(false);
            seal.SetActive(false);
            door.SetActive(false);
            isShowing = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
