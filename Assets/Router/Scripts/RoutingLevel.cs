using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutingLevel 
{
    public RoutingLevel DarkEndingDestination;
    public RoutingLevel NormalEndingDestination;
    public RoutingLevel HeroEndingDestination;

    public List<int> DarkCutscenes;
    public List<int> NormalCutscenes;
    public List<int> HeroCutscenes;

    public RoutingLevel(RoutingLevel dark, RoutingLevel normal, RoutingLevel hero)
    {
        DarkEndingDestination = dark;
        NormalEndingDestination = normal;
        HeroEndingDestination = hero;
    }

    public enum LevelMode { AllMissions, HeroDark, HeroNeutral, DarkNeutral, FinalLevel }

    public LevelMode levelMode
    {
        get
        {
            if (DarkEndingDestination == null && NormalEndingDestination == null && HeroEndingDestination == null)
            {
                return LevelMode.FinalLevel;
            }
            else
            {
                if (NormalEndingDestination != null)
                {
                    if (DarkEndingDestination == null)
                    {
                        return LevelMode.HeroNeutral;
                    }
                    else if (HeroEndingDestination == null)
                    {
                        return LevelMode.DarkNeutral;
                    }
                    else
                    {
                        return LevelMode.AllMissions;
                    }
                }
                else
                {
                    return LevelMode.HeroDark;
                }
            }
        }
        
    }
}
