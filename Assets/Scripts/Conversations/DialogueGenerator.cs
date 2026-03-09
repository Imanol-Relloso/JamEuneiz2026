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
    private GameObject dialoguePanel;

    public TextAsset ink;
    private Story story;
    public string[] sentences = { "dialogo1", "dialogo2", "dialogo3", "dialogo4" };
    public static DialogueGenerator Instance;

    [SerializeField] public TMP_Text dialogueText;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        dialogueName = transform.GetComponentInParent<CatBoat>().nameSystem.dialogueName;

        dialogueCountry = transform.GetComponentInParent<CatBoat>().countrySystem.dialogueCountry;

        dialogueLoad = transform.GetComponentInParent<CatBoat>().loadSystem.dialogueLoad;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMouseDown()
    {
        
    }
    public void StartDialogue()
    {
        story = new Story(ink.text);
        story.variablesState["NOMBRE"] = dialogueName.ToString();
        story.variablesState["PAIS"] = dialogueCountry.ToString();
        story.variablesState["CARGA"] = dialogueLoad.ToString();
        string knotRandom = sentences[Random.Range(0, sentences.Length)];
        story.ChoosePathString(knotRandom);

        string texto = story.Continue();
        dialogueText.text = texto;

    }
    
    
}
