using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoutingPathObject : MonoBehaviour
{
    public Text PathLabel;
    public InputField PathInputField;

    public Button UpButton;
    public Button DownButton;
    public Button VisualPickButton;
    public Button SettingsButton;
    public Button DeleteButton;

    public RoutingPathData PathData;

    public int index;

    public bool isValid
    {
        get { return PathData.ValidPathCode != string.Empty && PathData.ValidPathNumber > 0; }
    }

    public string DisplayText
    {
        get
        {
            if (isValid)
            {
                return (PathData.displayType == RoutingPathData.DisplayType.Number) ? PathData.ValidPathNumber.ToString() : PathData.ValidPathCode;
            }
            return "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Setup(RoutingPathData rpd)
    {
        PathData = rpd;
    }
}
