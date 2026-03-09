using UnityEngine;
using System.Collections.Generic;

public enum Country
{
    MiauLandia,
    Catarias,
    Gatonida
}
public class CountrySystem : GenericSystem
{
    public Country catCountry;
    public Country boatFlag;
    public Country dialogueCountry;

    public Sprite countrySprite;

    public void SetValues(bool errorFlag, bool errorDialogue, bool errorAllowedCountry)
    {
        if (!errorAllowedCountry)
        {
            catCountry = RandomEnum.GetRandomAllowedEnum<Country>(notAllowedCountry);

            if (errorFlag)
                boatFlag = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
            else
                boatFlag = catCountry;

            if (errorDialogue)
                dialogueCountry = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
            else
                dialogueCountry = catCountry;
        }
        else
        {
            catCountry = notAllowedCountry[Random.Range(0, notAllowedCountry.Count)];

            if (errorFlag)
                boatFlag = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
            else
                boatFlag = catCountry;

            if (errorDialogue)
                dialogueCountry = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
            else
                dialogueCountry = catCountry;
        }

        SetSprite();
    }

    private void SetSprite()
    {
        countrySprite = SpriteDictionary.Instance.GetCountrySprite(boatFlag);
    }

    public override bool IsCorrect()
    {
        if(catCountry != boatFlag || boatFlag != dialogueCountry)
            return false;

        if(notAllowedCountry.Contains(catCountry))
            return false;

        return true;
    }
}
