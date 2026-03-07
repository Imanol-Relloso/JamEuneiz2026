using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans; // Es como el transform pero un rectángulo para poder poner los sellos en el sitio
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // Habilita el click para uqe pueda agarrarse
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Se bloquea el click lo que hace que pueda 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
