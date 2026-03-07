using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GenericSystem 
{
    protected List<Name> notAllowedName;
    protected List<Country> notAllowedCountry;
    protected List<Load> notAllowedLoad;

    public void UpdateDayConditions()
    {
        notAllowedName = DayManager.Instance.dayConditions.notAllowedNames;
        notAllowedCountry = DayManager.Instance.dayConditions.notAllowedCountries;
        notAllowedLoad = DayManager.Instance.dayConditions.notAllowedLoad;
    }

    public virtual bool IsCorrect() {
        return true; 
    }
}
