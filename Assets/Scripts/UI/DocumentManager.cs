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
    [SerializeField] private GameObject greenPaw;
    [SerializeField] private GameObject redPaw;
    void Start()
    {
        greenPaw.SetActive(false);
        redPaw.SetActive(false);
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
                redPaw.SetActive(true);
                transform.position = resetPosition;
                AudioManager.Instance.PlayRedSeal();
                if (catBoat.IsValid())
                {
                    StartCoroutine(GameManager.Instance.Guess(false));
                }
                else
                {
                    StartCoroutine(GameManager.Instance.Guess(true));
                }
            }
            else if (gameObject.GetComponent<DocumentManager>().id == 2)
            {
                greenPaw.SetActive(true);
                transform.position = resetPosition;
                AudioManager.Instance.PlayGreenSeal();
                if (catBoat.IsValid())
                {
                    StartCoroutine(GameManager.Instance.Guess(true));
                }
                else
                {
                    StartCoroutine(GameManager.Instance.Guess(false));
                }
            }
        }
        else
        {
            transform.position = resetPosition;
        }
    }
}
