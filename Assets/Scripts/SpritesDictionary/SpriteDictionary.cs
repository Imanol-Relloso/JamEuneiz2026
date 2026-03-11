using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class SpriteDictionary : MonoBehaviour
{
    public static SpriteDictionary Instance;

    [Header("NAME SPRITES")]
    [SerializeField] private NameSprite[] nameSprites;
    [Header("COUNTRY SPRITES")]
    [SerializeField] private CountrySprite[] countrySprites;
    [Header("LOAD SPRITES")]
    [SerializeField] private LoadSprite[] loadSprites;

    private static Dictionary<Name, Sprite> nameDict;
    private static Dictionary<Country, Sprite> countryDict;
    private static Dictionary<Load, Sprite> loadDict;
    private static Dictionary<Name, AudioClip> nameAudio;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        InitializeDict();
    }

    private void InitializeDict()
    {
        nameDict = new Dictionary<Name, Sprite>();
        countryDict = new Dictionary<Country, Sprite>();
        loadDict = new Dictionary<Load, Sprite>();
        nameAudio = new Dictionary<Name, AudioClip>();

        foreach (NameSprite nameSprite in nameSprites)
            nameDict[nameSprite.name] = nameSprite.sprite;
        foreach (CountrySprite countrySprite in countrySprites)
            countryDict[countrySprite.country] = countrySprite.sprite;
        foreach (LoadSprite loadSprite in loadSprites)
            loadDict[loadSprite.Load] = loadSprite.sprite;
        foreach (NameSprite nameSprite in nameSprites)
            nameAudio[nameSprite.name] = nameSprite.sound;
    }

    public Sprite GetNameSprite(Name name)
    {
        return nameDict[name];
    }
    public Sprite GetCountrySprite(Country country)
    {
        return countryDict[country];
    }
    public Sprite GetLoadSprite(Load load)
    {
        return loadDict[load];
    }
    public AudioClip GetNameAudio(Name name)
    {
        return nameAudio[name];
    }
}
