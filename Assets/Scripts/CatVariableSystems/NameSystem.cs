using UnityEngine;
using System.Collections.Generic;

public enum Name
{
    Iker,
    Izaro,
    Ivan,
    Alejandro,
    Andrea,
    Joritz,
    Sei,
    Kai,
    Chaplin,
    Jonsey,
    Marcelo,
    Miaumanol,
    MiaudelCastrado,
    Elba,
    Tiramisu,
    Miauliver,
    Yaki,
    Katze,
    Miautsune,
    Morgan,
    Alain,
    Eros,
    Agro,
    Miauricio,
    Leopoldo,
    Serafin,
    Albus,
    Metalmaren,
    Zarpas,
    Sua,
    Bartolo,
    Coco
}
public class NameSystem : GenericSystem
{
    public Name catName;
    public Name dialogueName;

    public Sprite catSprite;
    public AudioClip catAudio;

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
        SetAudio();
    }

    private void SetSprite()
    {
        catSprite = SpriteDictionary.Instance.GetNameSprite(catName);
    }
    private void SetAudio()
    {
        catAudio = SpriteDictionary.Instance.GetNameAudio(catName);
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
