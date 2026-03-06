using UnityEngine;
public static class RandomEnum 
{
    public static ObjetoGenrico GetRandomEnum<ObjetoGenrico>()
    {
        ObjetoGenrico[] v = (ObjetoGenrico[])System.Enum.GetValues(typeof(ObjetoGenrico));
        return v[Random.Range(0, v.Length)];
    }
    public static ObjetoGenrico GetRandomDiferentEnum<ObjetoGenrico> (ObjetoGenrico original)
    {
        ObjetoGenrico newEnum;

        do
            newEnum = GetRandomEnum<ObjetoGenrico>();
        while (newEnum.Equals(original));

        return newEnum;
    }
}