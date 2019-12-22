using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraStageObject : MonoBehaviour
{
    public ExtraStageData Data;
    public Dropdown StageDropdown;
    public Dropdown MissionDropdown;
    public Button DeleteButton;
    public Toggle Key1Toggle;
    public Toggle Key2Toggle;
    public Toggle Key3Toggle;
    public Toggle Key4Toggle;
    public Toggle Key5Toggle;

    public void Setup(ExtraStageData extraStageData)
    {
        Data = extraStageData;

        StageDropdown.value = StageDropdown.options.IndexOf(StageDropdown.options.Find(s => s.text == extraStageData.levelName));

        MissionDropdown.value = MissionDropdown.options.IndexOf(MissionDropdown.options.Find(s => s.text == extraStageData.missionString));

        Key1Toggle.isOn = extraStageData.keys[0];
        Key2Toggle.isOn = extraStageData.keys[1];
        Key3Toggle.isOn = extraStageData.keys[2];
        Key4Toggle.isOn = extraStageData.keys[3];
        Key5Toggle.isOn = extraStageData.keys[4];
    }
}
