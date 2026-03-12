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

    [SerializeField] private AudioClip audioGatoTutorial;

    public IEnumerator StartTutorial(GameObject canvas)
    {
        tutorialStory = new Story(tutorialInk.text);

        catDialogueCanvas = canvas;
        textPos = catDialogueCanvas.GetComponentInChildren<TMP_Text>();

        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio", textPos, audioGatoTutorial);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator CorrectBoat()
    {
        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "acierto", textPos, audioGatoTutorial);
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator WrongBoat()
    {
        catDialogueCanvas.SetActive(true);
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo", textPos, audioGatoTutorial);
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }
    public void EndTutorial()
    {
        DayManager.Instance.tutorial = null;
    }
}
