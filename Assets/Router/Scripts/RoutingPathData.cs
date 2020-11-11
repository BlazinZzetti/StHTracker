using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutingPathData
{
    public string ValidPathCode = "";
    public int ValidPathNumber = 0;
    public enum DisplayType
    {
        NotValid,
        Number,
        Code,
    }

    public DisplayType displayType = DisplayType.NotValid;

    public bool[,] StageKeys = new bool[6,5];

    public RoutingPathData()
    {

    }

    public RoutingPathData(int pathNumber, string pathCode, DisplayType displayType, bool[,] stageKeys)
    {
        ValidPathNumber = pathNumber;
        ValidPathCode = pathCode;
        this.displayType = displayType;
        StageKeys = stageKeys;
    }
}
