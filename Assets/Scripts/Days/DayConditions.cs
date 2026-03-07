using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DayConditions 
{
    public List<Name> notAllowedNames = new List<Name>();
    public List<Country> notAllowedCountries = new List<Country>();
    public List<Load> notAllowedLoad = new List<Load>();
    public void ClearConditions()
    {
        notAllowedNames.Clear();
        notAllowedCountries.Clear();
        notAllowedLoad.Clear();
    }
    public void AddCondition<GenericObj>(GenericObj condition)
    {
        if(condition is Name name)
            notAllowedNames.Add(name);
        else if(condition is Country country)
            notAllowedCountries.Add(country);
        else if(condition is Load load)
            notAllowedLoad.Add(load);
    }
}