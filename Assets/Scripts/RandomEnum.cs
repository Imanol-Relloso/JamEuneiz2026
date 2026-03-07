using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public static class RandomEnum 
{
    public static ObjetoGenrico GetRandomEnum<ObjetoGenrico>()
    {
        ObjetoGenrico[] v = (ObjetoGenrico[])System.Enum.GetValues(typeof(ObjetoGenrico));
        return v[Random.Range(0, v.Length)];
    }
    public static ObjetoGenrico GetRandomDiferentEnum<ObjetoGenrico> (ObjetoGenrico original)
    {
        ObjetoGenrico newEnum = GetRandomEnum<ObjetoGenrico>();

        while (newEnum.Equals(original))
            newEnum = GetRandomEnum<ObjetoGenrico>();

        return newEnum;
    }

    public static ObjetoGenrico GetRandomAllowedEnum<ObjetoGenrico>(List<ObjetoGenrico> notAllowed)
    {
        ObjetoGenrico newEnum = GetRandomEnum<ObjetoGenrico>();

        while (notAllowed.Contains(newEnum))
            newEnum = GetRandomEnum<ObjetoGenrico>();

        return newEnum;
    }
}