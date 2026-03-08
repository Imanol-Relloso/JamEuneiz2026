using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
public class DialogueGenerator : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] sentences;
    private int index = 0;
    public float dialogueSpeed;
    public Name[] allNames;
    public Name dialogueName;
    public Country[] allCountries;
    public Country dialogueCountry;
    public Load[] allLoads;
    public Load dialogueLoad;
    public GameObject dialoguePanel;
    public CatBoat catBoat;


    void Start()
    {
        allNames = (Name[])System.Enum.GetValues(typeof(Name));
        dialogueName = transform.GetComponent<CatBoat>().nameSystem.dialogueName;

        allCountries = (Country[])System.Enum.GetValues(typeof(Country));
        dialogueCountry = transform.GetComponent<CatBoat>().countrySystem.dialogueCountry;

        allLoads = (Load[])System.Enum.GetValues(typeof(Load));
        dialogueLoad = transform.GetComponent<CatBoat>().loadSystem.dialogueLoad;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DialogueText.text = $"Miau, me llamo {dialogueName} vengo de {dialogueCountry} llevo {dialogueLoad}";
            //NextSentence();
        }   
    }
    public void NextSentence()
    {
        if (index <= sentences.Length -1)
        {
            StartCoroutine(WriteSentence());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false); 
    }
    IEnumerator WriteSentence()
    {
        foreach(char randomName in sentences[index].ToCharArray())
        {
            DialogueText.text += randomName;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
    }
}
