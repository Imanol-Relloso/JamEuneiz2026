using UnityEngine;

public abstract class GenericSystem<T>
{
    private T Value1; 
    private T Value2;

    public virtual void SetValues(bool error) 
    {
        Value1 = RandomEnum.GetRandomEnum<T>();

        if (error)
            Value2 = RandomEnum.GetRandomDiferentEnum<T>(Value1);
        else
            Value2 = Value1;
    }
    public virtual bool IsCorrect() {
        return Value1.Equals(Value2); 
    }
}
