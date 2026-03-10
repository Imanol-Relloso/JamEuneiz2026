using UnityEngine;
using System.Collections.Generic;

public enum Name
{
    Iker,
    Izaro,
    Oliver,
    Ivan,
    Alejandro,
    Andrea,
    Joritz,
    Imanol,
    Sei,
    Kai,
    Chaplin,
    Jonsey,
    Marcelo,
    Miaumanol,
}
public class NameSystem : GenericSystem
{
    public Name catName;
    public Name dialogueName;

    public Sprite catSprite;

    public void SetValues(bool errorNombre, bool errorBlackList)
    {
        if (!errorBlackList)
        {
            catName = RandomEnum.GetRandomAllowedEnum<Name>(notAllowedName);

            if (errorNombre)
                dialogueName = RandomEnum.GetRandomDiferentEnum(catName);
            else
                dialogueName = catName;
        }
        else
        {
            catName = notAllowedName[Random.Range(0, notAllowedName.Count)];

            if (errorNombre)
                dialogueName = RandomEnum.GetRandomDiferentEnum(catName);
            else
                dialogueName = catName;
        }
        SetSprite();
    }

    private void SetSprite()
    {
        catSprite = SpriteDictionary.Instance.GetNameSprite(catName);
    }

    public override bool IsCorrect()
    {
        if(catName != dialogueName)
            return false;

        if(notAllowedName.Contains(catName))
            return false;

        return true;
    }
}
