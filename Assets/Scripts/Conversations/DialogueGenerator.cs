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
    public Name randomName;
    public Country[] allCountries;
    public Country randomCountry;
    public GameObject dialoguePanel;
    void Start()
    {
        dialoguePanel.SetActive(true);

        allNames = (Name[])System.Enum.GetValues(typeof(Name));
        randomName = allNames[Random.Range(0, allNames.Length)];

        allCountries = (Country[])System.Enum.GetValues(typeof(Country));
        randomCountry =  allCountries[Random.Range(0, allCountries.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
        
    }
    public void NextSentence()
    {
        if (index <= sentences.Length -1)
        {
            DialogueText.text = $"Miau, me llamo {randomName} vengo de {randomCountry}";
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
