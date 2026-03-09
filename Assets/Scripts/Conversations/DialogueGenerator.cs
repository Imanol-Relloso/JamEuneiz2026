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
        dialogueName = transform.GetComponentInParent<CatBoat>().nameSystem.dialogueName;

        dialogueCountry = transform.GetComponentInParent<CatBoat>().countrySystem.dialogueCountry;

        dialogueLoad = transform.GetComponentInParent<CatBoat>().loadSystem.dialogueLoad;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void FirstSentence()
    {
        string sentence = sentences[Random.Range(0, sentences.Length)];
        
        sentence = sentence.Replace("{NOMBRE}", dialogueName.ToString());
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
