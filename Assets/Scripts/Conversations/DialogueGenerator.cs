using Ink.Runtime;
using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class DialogueGenerator : MonoBehaviour
{
    private Name dialogueName;
    private Country dialogueCountry;
    private Load dialogueLoad;
    private CatBoat catBoat;

    private GameObject dialoguePanel;

    public TextAsset ink;
    private Story story;
    public string[] sentences = { "dialogo1", "dialogo2", "dialogo3", "dialogo4", "dialogo5", "dialogo6" };

    [SerializeField] public TMP_Text dialogueText;

    private string knotRandom;

    private string texto;
    public bool isEnded = false;
    public bool isStarted = false;
    void Start()
    {
        gameObject.SetActive(false);

        catBoat = GetComponentInParent<CatBoat>();

        dialogueName = catBoat.nameSystem.dialogueName;

        dialogueCountry = catBoat.countrySystem.dialogueCountry;

        dialogueLoad = catBoat.loadSystem.dialogueLoad;

        SetDialogue();
    }

    private void SetDialogue()
    {
        story = new Story(ink.text);
        story.variablesState["NOMBRE"] = dialogueName.ToString();
        story.variablesState["PAIS"] = dialogueCountry.ToString();
        story.variablesState["CARGA"] = dialogueLoad.ToString();
        knotRandom = sentences[Random.Range(0, sentences.Length)];
    }
    public void StartDialogue()
    {
        if (!EveryDialogueGenerator.Instance.dialogueActive)
        {
            gameObject.SetActive(true);
            EveryDialogueGenerator.Instance.StartDialogue(story, knotRandom, dialogueText, CatBoatManager.instance.currentBoat.GetComponent<CatBoat>().nameSystem.catAudio);
        }
    }
}
