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
    public Button SettingsButton;
    public Button DeleteButton;

    public void Setup(ExtraStageData extraStageData)
    {
        Data = extraStageData;

        StageDropdown.value = StageDropdown.options.IndexOf(StageDropdown.options.Find(s => s.text == extraStageData.levelName));

        MissionDropdown.value = MissionDropdown.options.IndexOf(MissionDropdown.options.Find(s => s.text == extraStageData.missionString));
    }
}
