using Ink.Runtime;
using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;

    [SerializeField] private int currentDay;

    [Header("PREFABS DE LOS DIAS")]
    [SerializeField] private Day[] days;

    [Header("TRANSICION ENTRE DIAS")]
    [SerializeField] private GameObject transitionCanvas;
    [SerializeField] private UnityEngine.UI.Image fadeImage;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private float textTime = 2f;

    public TutorialCoroutines tutorial;

    [SerializeField] private GameObject catDialogueCanvas;
    [SerializeField] private TextAsset dailyInk;
    [SerializeField] private AudioClip tutorialCatSound;
    private TMP_Text textPos;
    private Story dailyStory;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        textPos = catDialogueCanvas.GetComponentInChildren<TMP_Text>();
    }
    public void StartDay()
    {
        if (currentDay < 0 || currentDay >= days.Length)
        {
            Debug.Log("No hay más días disponibles");
            return;
        }

        days[currentDay].InitializeDay(); 

        StartCoroutine(StartDayCoroutine());
    }

    public IEnumerator NextDay()
    {
        if (days[currentDay].tutorialDay)
            yield return StartCoroutine(tutorial.EndTutorial());
        else
            yield return StartCoroutine(FinalDialogue());

        if (GetCurrentDay().errores < 3)
            currentDay++;
        StartDay();
    }

    public DayConditions GetDayConditions()
    {
        return GetCurrentDay().dayConditions;
    }

    public Day GetCurrentDay()
    {
        return days[currentDay];
    }

    private IEnumerator StartDayCoroutine()
    {
        yield return StartCoroutine(DayTransition());

        if (days[currentDay].tutorialDay)
        {
            tutorial = days[currentDay].GetComponent<TutorialCoroutines>();
            yield return StartCoroutine(tutorial.StartTutorial(catDialogueCanvas));
        }

        GameManager.Instance.NextBoat();
    }

    private IEnumerator DayTransition()
    {
        transitionCanvas.SetActive(true);

        dayText.text = "DÍA " + currentDay;

        yield return StartCoroutine(FadeTransition(0, 1));

        yield return new WaitForSeconds(textTime);

        yield return StartCoroutine(FadeTransition(1, 0));

        transitionCanvas.SetActive(false);
    }
    private IEnumerator FadeTransition(float start, float end)
    {
        float t = 0;
        Color backColor = fadeImage.color;

        while (t < fadeTime)
        {
            float value = Mathf.Lerp(start, end, t / fadeTime);

            fadeImage.color = new Color(backColor.r, backColor.g, backColor.b, value);
            dayText.alpha = value;

            t += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FinalDialogue()
    {
        SetFinalDialogue();

        catDialogueCanvas.SetActive(true);

        if (GetCurrentDay().errores < 3)
            EveryDialogueGenerator.Instance.StartDialogue(dailyStory, "daily1", textPos, tutorialCatSound);
        else
            EveryDialogueGenerator.Instance.StartDialogue(dailyStory, "daily2", textPos, tutorialCatSound);

        while (EveryDialogueGenerator.Instance.dialogueActive)
            yield return null;
        catDialogueCanvas.SetActive(false);
    }

    private void SetFinalDialogue()
    {
        dailyStory = new Story(dailyInk.text);
        dailyStory.variablesState["ERROR"] = GetCurrentDay().errores.ToString();
    }
}