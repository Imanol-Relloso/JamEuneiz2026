using UnityEngine;
using System.Collections.Generic;
public enum Load {
    anzuelos,
    cañas,
    latas,
    pecesNormales,
    pecesLargos,
    pelotas
}
public class LoadSystem : GenericSystem
{
    public Load boatLoad;
    public Load dialogueLoad;

    public Sprite loadSprite1;
    public Sprite loadSprite2;
    public Sprite loadSprite3;

    public void SetValues(bool errorDialogue, bool errorNotAllowed)
    {
        if (!errorNotAllowed)
        {
            boatLoad = RandomEnum.GetRandomAllowedEnum<Load>(notAllowedLoad);

            if (errorDialogue)
                dialogueLoad = RandomEnum.GetRandomDiferentEnum(boatLoad);
            else
                dialogueLoad = boatLoad;
        }
        else
        {
            boatLoad = notAllowedLoad[Random.Range(0, notAllowedLoad.Count)];

            if (errorDialogue)
                dialogueLoad = RandomEnum.GetRandomDiferentEnum(boatLoad);
            else
                dialogueLoad = boatLoad;
        }
        SetSprite();
    }

    private void SetSprite()
    {
        loadSprite1 = SpriteDictionary.Instance.GetLoadSpriteArr(boatLoad)[0];
        loadSprite2 = SpriteDictionary.Instance.GetLoadSpriteArr(boatLoad)[1];
        loadSprite3 = SpriteDictionary.Instance.GetLoadSpriteArr(boatLoad)[2];
    }
    public override bool IsCorrect()
    {
        if(boatLoad != dialogueLoad)
            return false;

        if(notAllowedLoad.Contains(dialogueLoad))
            return false;

        return true;
    }
}
