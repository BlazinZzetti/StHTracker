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

    public string ValidPathCode = "";
    public int ValidPathNumber = 0;

    public bool isValid
    {
        get { return ValidPathCode != string.Empty && ValidPathNumber > 0; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
