using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PathSettingsControl : MonoBehaviour
{
    public Text SettingControlLabelText;

    public StageKeySettingsOptions Stage1KeyOptions;
    public StageKeySettingsOptions Stage2KeyOptions;
    public StageKeySettingsOptions Stage3KeyOptions;
    public StageKeySettingsOptions Stage4KeyOptions;
    public StageKeySettingsOptions Stage5KeyOptions;
    public StageKeySettingsOptions Stage6KeyOptions;

    public Dropdown DisplayModeDropdown;

    public Button CloseButton;

    private void Awake()
    {
        CloseButton.onClick.RemoveAllListeners();

        CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void Setup(RoutingPathObject pathDataObject)
    {
        SettingControlLabelText.text = "Path #" + pathDataObject.index + " Settings - Path " + pathDataObject.PathData.ValidPathNumber + " - " + pathDataObject.PathData.ValidPathCode;

        DisplayModeDropdown.onValueChanged.RemoveAllListeners();
        DisplayModeDropdown.interactable = pathDataObject.PathData.displayType != RoutingPathData.DisplayType.NotValid;
        var dropdownValue = (int)pathDataObject.PathData.displayType - 1;
        DisplayModeDropdown.value = (dropdownValue < 0) ? 0 : dropdownValue;

        DisplayModeDropdown.onValueChanged.AddListener((value) => { dropdownValueChanged(pathDataObject); });

        Stage1KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage1KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage1KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage1KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage1KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();
                                             
        Stage2KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage2KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage2KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage2KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage2KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();
                                               
        Stage3KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage3KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage3KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage3KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage3KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();
                                               
        Stage4KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage4KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage4KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage4KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage4KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();
                                           
        Stage5KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage5KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage5KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage5KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage5KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();
                                                  
        Stage6KeyOptions.Key1Toggle.onValueChanged.RemoveAllListeners();
        Stage6KeyOptions.Key2Toggle.onValueChanged.RemoveAllListeners();
        Stage6KeyOptions.Key3Toggle.onValueChanged.RemoveAllListeners();
        Stage6KeyOptions.Key4Toggle.onValueChanged.RemoveAllListeners();
        Stage6KeyOptions.Key5Toggle.onValueChanged.RemoveAllListeners();

        Stage1KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[0, 0];
        Stage1KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[0, 1];
        Stage1KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[0, 2];
        Stage1KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[0, 3];
        Stage1KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[0, 4];

        Stage2KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[1, 0];
        Stage2KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[1, 1];
        Stage2KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[1, 2];
        Stage2KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[1, 3];
        Stage2KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[1, 4];

        Stage3KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[2, 0];
        Stage3KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[2, 1];
        Stage3KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[2, 2];
        Stage3KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[2, 3];
        Stage3KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[2, 4];

        Stage4KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[3, 0];
        Stage4KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[3, 1];
        Stage4KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[3, 2];
        Stage4KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[3, 3];
        Stage4KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[3, 4];

        Stage5KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[4, 0];
        Stage5KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[4, 1];
        Stage5KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[4, 2];
        Stage5KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[4, 3];
        Stage5KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[4, 4];

        Stage6KeyOptions.Key1Toggle.isOn = pathDataObject.PathData.StageKeys[5, 0];
        Stage6KeyOptions.Key2Toggle.isOn = pathDataObject.PathData.StageKeys[5, 1];
        Stage6KeyOptions.Key3Toggle.isOn = pathDataObject.PathData.StageKeys[5, 2];
        Stage6KeyOptions.Key4Toggle.isOn = pathDataObject.PathData.StageKeys[5, 3];
        Stage6KeyOptions.Key5Toggle.isOn = pathDataObject.PathData.StageKeys[5, 4];

        Stage1KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 0, 0, Stage1KeyOptions.Key1Toggle.isOn));
        Stage1KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 0, 1, Stage1KeyOptions.Key2Toggle.isOn));
        Stage1KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 0, 2, Stage1KeyOptions.Key3Toggle.isOn));
        Stage1KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 0, 3, Stage1KeyOptions.Key4Toggle.isOn));
        Stage1KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 0, 4, Stage1KeyOptions.Key5Toggle.isOn));

        Stage2KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 1, 0, Stage2KeyOptions.Key1Toggle.isOn));
        Stage2KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 1, 1, Stage2KeyOptions.Key2Toggle.isOn));
        Stage2KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 1, 2, Stage2KeyOptions.Key3Toggle.isOn));
        Stage2KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 1, 3, Stage2KeyOptions.Key4Toggle.isOn));
        Stage2KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 1, 4, Stage2KeyOptions.Key5Toggle.isOn));

        Stage3KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 2, 0, Stage3KeyOptions.Key1Toggle.isOn));
        Stage3KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 2, 1, Stage3KeyOptions.Key2Toggle.isOn));
        Stage3KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 2, 2, Stage3KeyOptions.Key3Toggle.isOn));
        Stage3KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 2, 3, Stage3KeyOptions.Key4Toggle.isOn));
        Stage3KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 2, 4, Stage3KeyOptions.Key5Toggle.isOn));

        Stage4KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 3, 0, Stage4KeyOptions.Key1Toggle.isOn));
        Stage4KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 3, 1, Stage4KeyOptions.Key2Toggle.isOn));
        Stage4KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 3, 2, Stage4KeyOptions.Key3Toggle.isOn));
        Stage4KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 3, 3, Stage4KeyOptions.Key4Toggle.isOn));
        Stage4KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 3, 4, Stage4KeyOptions.Key5Toggle.isOn));

        Stage5KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 4, 0, Stage5KeyOptions.Key1Toggle.isOn));
        Stage5KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 4, 1, Stage5KeyOptions.Key2Toggle.isOn));
        Stage5KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 4, 2, Stage5KeyOptions.Key3Toggle.isOn));
        Stage5KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 4, 3, Stage5KeyOptions.Key4Toggle.isOn));
        Stage5KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 4, 4, Stage5KeyOptions.Key5Toggle.isOn));

        Stage6KeyOptions.Key1Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 5, 0, Stage6KeyOptions.Key1Toggle.isOn));
        Stage6KeyOptions.Key2Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 5, 1, Stage6KeyOptions.Key2Toggle.isOn));
        Stage6KeyOptions.Key3Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 5, 2, Stage6KeyOptions.Key3Toggle.isOn));
        Stage6KeyOptions.Key4Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 5, 3, Stage6KeyOptions.Key4Toggle.isOn));
        Stage6KeyOptions.Key5Toggle.onValueChanged.AddListener((value) => updateKeyValue(pathDataObject.PathData, 5, 4, Stage6KeyOptions.Key5Toggle.isOn));
    }

    private void dropdownValueChanged(RoutingPathObject pathDataObject)
    {
        pathDataObject.PathData.displayType = (RoutingPathData.DisplayType)DisplayModeDropdown.value + 1;
        pathDataObject.PathInputField.text = pathDataObject.DisplayText;
    }

    private void updateKeyValue(RoutingPathData pathData, int stageIndex, int keyIndex, bool isOn)
    {
        pathData.StageKeys[stageIndex, keyIndex] = isOn;
    }
}
