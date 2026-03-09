using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentManager : MonoBehaviour
{
    public int id;
    private CatBoat catBoat;
    private GameManager gameManager;

    [SerializeField] private Transform target;
    private float putDistance = 1f;
    private Vector3 resetPosition;
    void Start()
    {
        resetPosition = transform.position;
        catBoat = GetComponent<CatBoat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
    }
    public void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;
    }

    public void OnMouseUp()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < putDistance)
        {
            transform.position = target.position;
            if (gameObject.GetComponent<DocumentManager>().id == 1)
            {
                Debug.Log("gatito no aprobado");
                if (catBoat.IsValid())
                {
                    gameManager.CorrectGuess();
                }
                else
                {
                    gameManager.IncorrectGuess();
                }
            }
            else if (gameObject.GetComponent<DocumentManager>().id == 2)
            {
                Debug.Log("Gatito aprobado");
                if (catBoat.IsValid())
                {
                    gameManager.CorrectGuess();
                }
                else
                {
                    gameManager.IncorrectGuess();
                }
            }
            else
            {
                Debug.Log("no pasa nada");
            }
        }
        else
        {
            transform.position = resetPosition;
        }
    }
}
