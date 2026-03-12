using Ink.Runtime;
using System.Collections;
using TMPro;
using UnityEngine;

public class EveryDialogueGenerator : MonoBehaviour
{
    public static EveryDialogueGenerator Instance;

    [SerializeField]private float dialogueSpeed = 0.05f;

    private bool isTyping = false;
    public bool dialogueActive = false;

    private Coroutine typingCoroutine;
    private string currentText;

    private Story currentStory;
    private TMP_Text currentTmp;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void StartDialogue(Story story, string text, TMP_Text dialogueText, AudioClip audioClip)
    {
        currentStory = story;
        currentTmp = dialogueText;

        currentStory.ChoosePathString(text);
        currentText = currentStory.Continue();

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(WriteLine(currentText, audioClip));

        dialogueActive = true;
    }
    private IEnumerator WriteLine(string text, AudioClip audioClip)
    {
        isTyping = true;
        currentTmp.text = "";

        AudioManager.Instance.PlayMeow(audioClip);

        foreach (char letter in text.ToCharArray())
        {
            currentTmp.text += letter;
            yield return new WaitForSeconds(dialogueSpeed);
        }

        AudioManager.Instance.StopMeow();

        isTyping = false;
    }
    public void AutomaticDialogue()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        currentTmp.text = currentText;
        isTyping = false;

        AudioManager.Instance.StopMeow();
    }

    public void EndDialogue()
    {
        if (currentTmp != null)
            currentTmp.text = "";

        dialogueActive = false;

        AudioManager.Instance.StopMeow();
    }

    public void Click()
    {
        if(!dialogueActive)return;

        if (isTyping)
            AutomaticDialogue();
        else
            EndDialogue();
    }
}
