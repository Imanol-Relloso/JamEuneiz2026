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
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio1", textPos, audioGatoTutorial);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio2", textPos, audioGatoTutorial);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio3", textPos, audioGatoTutorial);
       
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio4", textPos, audioGatoTutorial);
        
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        
        EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "inicio5", textPos, audioGatoTutorial);
        
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator CorrectBoat()
    {
        catDialogueCanvas.SetActive(true);
        if(CatBoatManager.instance.currentBoat.GetComponent<CatBoat>().IsValid())
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "acierto1", textPos, audioGatoTutorial);
        else
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "acierto2", textPos, audioGatoTutorial);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    public IEnumerator WrongBoat()
    {
        catDialogueCanvas.SetActive(true);
        if(CatBoatManager.instance.currentBoat.GetComponent<CatBoat>().ErrorEnNombre)
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo2", textPos, audioGatoTutorial);
        else if(CatBoatManager.instance.currentBoat.GetComponent<CatBoat>().ErrorEnPaisPermitido)
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo3", textPos, audioGatoTutorial);
        else if(CatBoatManager.instance.currentBoat.GetComponent<CatBoat>().ErrorEnBandera)
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo4", textPos, audioGatoTutorial);
        else
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "fallo1", textPos, audioGatoTutorial);
        
        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }
    public IEnumerator EndTutorial()
    {
        catDialogueCanvas.SetActive(true);

        if (DayManager.Instance.GetCurrentDay().errores < 3)
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "final1", textPos, audioGatoTutorial);
        else
            EveryDialogueGenerator.Instance.StartDialogue(tutorialStory, "final2", textPos, audioGatoTutorial);

        while (EveryDialogueGenerator.Instance.dialogueActive)
                yield return null;

        catDialogueCanvas.SetActive(false);

        DayManager.Instance.tutorial = null;
    }
}
