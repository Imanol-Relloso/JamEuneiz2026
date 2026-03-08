using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform; // Es como el transform pero un rectángulo para poder poner los sellos en el sitio
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    [SerializeField] private GameObject sealPointput;
    public int id;
    private Vector2 resetPosition; 
    public float snapDistance = 0.5f; 
    public RectTransform sealPoint;
    public CatBoat catBoat;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        resetPosition = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        float distance = Vector2.Distance(rectTransform.anchoredPosition, sealPoint.anchoredPosition);

        if (distance <= snapDistance)
        {
            rectTransform.anchoredPosition = sealPoint.anchoredPosition;

            GameObject seal = eventData.pointerDrag;

            if (eventData.pointerDrag.GetComponent<DocumentManager>().id == 1)
            {
                Debug.Log("gatito no aprobado");
                catBoat.IsValid();
            }
            else if (eventData.pointerDrag.GetComponent<DocumentManager>().id == 2)
            {
                Debug.Log("Gatito aprobado");
                catBoat.IsValid();
            }
            else
            {
                Debug.Log("no pasa nada");
            }
        }
        else
        {
            rectTransform.anchoredPosition = resetPosition;
        }
    }
}
