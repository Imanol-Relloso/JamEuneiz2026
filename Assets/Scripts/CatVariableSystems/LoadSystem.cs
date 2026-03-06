using UnityEngine;
public enum Load {
    None,
    si
}
public class LoadSystem : GenericSystem<Load>
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
