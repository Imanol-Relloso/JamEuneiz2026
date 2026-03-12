using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentManager : MonoBehaviour
{
    public int id;
    private CatBoat catBoat;

    [SerializeField] private Transform target;
    private float putDistance = 1f;
    private Vector3 resetPosition;
    void Start()
    {
        resetPosition = transform.position;
        catBoat = GetComponentInParent<CatBoat>();
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
                AudioManager.Instance.PlayRedSeal();
                if (!catBoat.IsValid())
                {
                    GameManager.Instance.IncorrectGuess();

                }
                else
                {
                    GameManager.Instance.CorrectGuess();

                }
            }
            else if (gameObject.GetComponent<DocumentManager>().id == 2)
            {
                AudioManager.Instance.PlayGreenSeal();
                if (catBoat.IsValid())
                {
                    GameManager.Instance.CorrectGuess();
                }
                else
                {
                    GameManager.Instance.IncorrectGuess();
                }
            }
        }
        else
        {
            transform.position = resetPosition;
        }
    }
}
