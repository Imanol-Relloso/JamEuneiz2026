using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject boat, deck, deckDoor, boatDoor, documentDisplayed, document, closeDocument, cat;
    private RaycastHit2D hit;
    [SerializeField] private DialogueGenerator dialogueGenerator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
            if (hit.collider != null)
            {
                Activation();
            }
        }
    }
    public void Activation()
    {
        if (hit.collider.gameObject == document)
        {
            boat.SetActive(false);
            documentDisplayed.SetActive(true);
            document.SetActive(false);
            closeDocument.SetActive(true);
            boatDoor.SetActive(false);
            deckDoor.SetActive(false);
            deck.SetActive(false);
        }
        else if (hit.collider.gameObject == closeDocument)
        {
            boat.SetActive(true);
            documentDisplayed.SetActive(false);
            document.SetActive(true);
            closeDocument.SetActive(false);
            boatDoor.SetActive(true);
            deckDoor.SetActive(false);
            deck.SetActive(false);
        }
        else if (hit.collider.gameObject == boatDoor)
        {
            boat.SetActive(false);
            documentDisplayed.SetActive(false);
            document.SetActive(false);
            closeDocument.SetActive(false);
            boatDoor.SetActive(false);
            deckDoor.SetActive (true);
            deck.SetActive(true);
        }
        else if (hit.collider.gameObject == deckDoor)
        {
            boat.SetActive(true);
            documentDisplayed.SetActive(false);
            document.SetActive(true);
            closeDocument.SetActive(false);
            boatDoor.SetActive(true);
            deckDoor.SetActive(false);
            deck.SetActive(false);
        }
        else if (hit.collider.gameObject == cat)
        {
            if (dialogueGenerator.isTyping == false)
            {
                dialogueGenerator.StartDialogue();
                dialogueGenerator.isEnded = false;
            }
           else if (dialogueGenerator.isTyping && dialogueGenerator.isEnded == false)
           {
                dialogueGenerator.AutomaticDialogue();
                
           }
           //else if (dialogueGenerator.isTyping && dialogueGenerator.isEnded)
           //{
               // dialogueGenerator.EndDialogue();
          // }

        }

    }
    // Update is called once per frame


}
