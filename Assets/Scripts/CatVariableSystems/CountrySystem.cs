using UnityEngine;
public enum Country
{
    MiauLandia,
    Catarias,
    Gatonida
}
public class CountrySystem : GenericSystem <Country>
{
    public Country catCountry;
    public Country boatFlag;
    public Country dialogueCountry;

    public void SetValues(bool errorFlag, bool errorDialogue)
    {
        catCountry = RandomEnum.GetRandomEnum<Country>();

        if (errorFlag)
            boatFlag = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
        else
            boatFlag = catCountry;

        if (errorDialogue)
            dialogueCountry = RandomEnum.GetRandomDiferentEnum<Country>(catCountry);
        else
            dialogueCountry = catCountry;
    }

    public override bool IsCorrect()
    {
        return catCountry == boatFlag && boatFlag == dialogueCountry;
    }
}
