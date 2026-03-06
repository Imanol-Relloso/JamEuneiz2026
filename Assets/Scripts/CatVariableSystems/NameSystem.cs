using UnityEngine;
public enum Name
{
    si,
    no,
    sisi
}
public class NameSystem : GenericSystem <Name>
{
    public override void SetValues(bool error)
    {
        base.SetValues(error);
    }

    public override bool IsCorrect()
    {
        return base.IsCorrect();
    }
}
