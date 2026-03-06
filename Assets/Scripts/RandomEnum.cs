using UnityEngine;
public static class RandomEnum 
{
    public static T GetRandomEnum<T>()
    {
        T[] v = (T[])System.Enum.GetValues(typeof(T));
        return v[Random.Range(0, v.Length)];
    }
    public static T GetRandomDiferentEnum<T> (T original)
    {
        T newEnum;

        do
            newEnum = GetRandomEnum<T>();
        while (newEnum.Equals(original));

        return newEnum;
    }
}