using UnityEngine;
using System.Collections.Generic;
public enum Load {
    None,
    si
}
public class LoadSystem : GenericSystem
{
    public Load boatLoad;
    public Load dialogueLoad;

    public Sprite loadSprite;

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
        loadSprite = SpriteDictionary.Instance.GetLoadSprite(boatLoad);
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
