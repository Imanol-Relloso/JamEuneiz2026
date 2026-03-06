using UnityEngine;

public abstract class GenericSystem<ObjetoGenrico>
{
    public ObjetoGenrico Value1; 
    public ObjetoGenrico Value2;

    public virtual void SetValues(bool error) 
    {
        Value1 = RandomEnum.GetRandomEnum<ObjetoGenrico>();

        if (error)
            Value2 = RandomEnum.GetRandomDiferentEnum<ObjetoGenrico>(Value1);
        else
            Value2 = Value1;
    }
    public virtual bool IsCorrect() {
        return Value1.Equals(Value2); 
    }
}
