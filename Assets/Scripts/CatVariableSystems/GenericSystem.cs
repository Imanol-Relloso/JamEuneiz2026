using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GenericSystem 
{
    protected List<Name> notAllowedName;
    protected List<Country> notAllowedCountry;
    protected List<Load> notAllowedLoad;

    DayConditions rules;

    public void UpdateDayConditions()
    {
        rules = DayManager.Instance.GetDayConditions();

        notAllowedName = rules.notAllowedNames;
        notAllowedCountry = rules.notAllowedCountries;
        notAllowedLoad = rules.notAllowedLoad;
    }

    public virtual bool IsCorrect() {
        return true; 
    }
}
