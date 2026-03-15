using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject boat, deck, deckDoor, boatDoor, documentDisplayed, document, closeDocument, cat, catDialogue;
    [SerializeField] private DialogueGenerator dialogueGenerator;
    private GameObject election;
    private int preference;

    private GameObject book;
    private GameObject pauseMenu;
    private void Start()
    {
        book = CoinManger.Instance.book;
        pauseMenu = CoinManger.Instance.pauseMenu;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!pauseMenu.activeSelf && !book.activeSelf)
            {
                preference = 0;
                election = null;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

                foreach (Collider2D h in hits)
                {
                    if (h.gameObject == cat)
                    {
                        election = h.gameObject;
                        preference = 4;
                    }
                    else if (h.gameObject == document && preference < 3)
                    {
                        election = h.gameObject;
                        preference = 3;
                    }
                    else if (h.gameObject == closeDocument && preference < 2)
                    {
                        election = h.gameObject;
                        preference = 2;
                    }
                    else if (h.gameObject == deckDoor && preference < 1)
                    {
                        election = h.gameObject;
                        preference = 1;
                    }
                    else if (h.gameObject == boatDoor && preference == 0)
                        election = h.gameObject;
                }

                Activation(election);
            }
        }
    }
    public void Activation(GameObject go)
    {
        catDialogue.SetActive(false);

        if (go == document)
        {
            boat.SetActive(false);
            documentDisplayed.SetActive(true);
            document.SetActive(false);
            closeDocument.SetActive(true);
            boatDoor.SetActive(false);
            deckDoor.SetActive(false);
            deck.SetActive(false);
            cat.SetActive(false);
        }
        else if (go == closeDocument)
        {
            boat.SetActive(true);
            documentDisplayed.SetActive(false);
            document.SetActive(true);
            closeDocument.SetActive(false);
            boatDoor.SetActive(true);
            deckDoor.SetActive(false);
            deck.SetActive(false);
            cat.SetActive(true);
        }
        else if (go == cat)
        {
            catDialogue.SetActive(true);
            dialogueGenerator.StartDialogue();

        }
        else if (go == deckDoor)
        {
            AudioManager.Instance.PlayDoor();
            boat.SetActive(true);
            documentDisplayed.SetActive(false);
            document.SetActive(true);
            closeDocument.SetActive(false);
            boatDoor.SetActive(true);
            deckDoor.SetActive(false);
            deck.SetActive(false);
            cat.SetActive(true);
        }
        else if (go == boatDoor)
        {
            AudioManager.Instance.PlayDoor();
            boat.SetActive(false);
            documentDisplayed.SetActive(false);
            document.SetActive(false);
            closeDocument.SetActive(false);
            boatDoor.SetActive(false);
            deckDoor.SetActive(true);
            deck.SetActive(true);
            cat.SetActive(false);
        }
    }
}
