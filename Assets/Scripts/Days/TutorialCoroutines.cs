using Ink.Runtime;
using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialCoroutines : MonoBehaviour
{
    [SerializeField] private TextAsset tutorialInk;
    private GameObject catDialogueCanvas;
    private TMP_Text textPos;

    private Story tutorialStory;

    public IEnumerator StartTutorial(GameObject canvas)
    {
        tutorialStory = new Story(tutorialInk.text);


        catDialogueCanvas = canvas;
        textPos = catDialogueCanvas.GetComponentInChildren<TMP_Text>();

        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio", textPos);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator CorrectBoat()
    {
        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "acierto", textPos);
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator WrongBoat()
    {
        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo", textPos);
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }
    public void EndTutorial()
    {
        DayManager.Instance.tutorial = null;
    }
}
