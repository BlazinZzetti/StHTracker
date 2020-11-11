using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraStageManager : MonoBehaviour
{
    public Button AddStageButton;
    public Button CloseButton;
    public ScrollRect ContentContainer;

    public List<ExtraStageObject> ExtraStages;

    public RectTransform content
    {
        get { return ContentContainer.content; }
    }

    private void Awake()
    {
        AddStageButton.onClick.AddListener(AddStage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStage()
    {
        var extraStageObject = Instantiate(Resources.Load("ExtraStageObject")) as GameObject;
        ExtraStageObject extraStage = extraStageObject.GetComponent<ExtraStageObject>();
        extraStage.transform.SetParent(content, false);
        extraStage.StageDropdown.AddOptions(new List<string>(Common.LevelNames));
        UpdateMissionDropdown(extraStage);
        extraStage.StageDropdown.onValueChanged.AddListener((value) => UpdateMissionDropdown(extraStage));

        extraStage.DeleteButton.onClick.AddListener(() => OnExtraStageDeleteButtonPressed(extraStage));

        ExtraStages.Add(extraStage);

        //routingPath.UpButton.onClick.AddListener(() => OnRoutingPathUpButtonPressed(routingPath));
        //routingPath.DownButton.onClick.AddListener(() => OnRoutingPathDownButtonPressed(routingPath));
        //routingPath.DeleteButton.onClick.AddListener(() => OnRoutingPathDeleteButtonPressed(routingPath));
        //routingPath.SettingsButton.onClick.AddListener(() => ShowPathSettingsControlPanel(routingPath));

        //routingPath.PathInputField.onEndEdit.AddListener(delegate { OnRoutingPathInputFieldEditEnd(routingPath); });

        //RoutingPaths.Add(routingPath);

        //refreshInterface();
    }

    private void UpdateMissionDropdown(ExtraStageObject extraStage)
    {
        var missions = Common.Levels.Find(l => l.Name == Common.LevelNames[extraStage.StageDropdown.value]).Missions;
        extraStage.MissionDropdown.ClearOptions();

        var missionStrings = new List<string>();

        foreach (var mission in missions)
        {
            missionStrings.Add(mission.ToString());
        }

        extraStage.MissionDropdown.AddOptions(missionStrings);

    }

    private void OnExtraStageDeleteButtonPressed(ExtraStageObject extraStage)
    {
        ExtraStages.Remove(extraStage);
        Destroy(extraStage.gameObject);
    }

    internal void AddStage(ExtraStageData extraStageData)
    {
        var extraStageObject = Instantiate(Resources.Load("ExtraStageObject")) as GameObject;
        ExtraStageObject extraStage = extraStageObject.GetComponent<ExtraStageObject>();

        extraStage.transform.SetParent(content, false);
        extraStage.StageDropdown.AddOptions(new List<string>(Common.LevelNames));

        extraStage.Setup(extraStageData);

        UpdateMissionDropdown(extraStage);

        extraStage.MissionDropdown.value = extraStage.MissionDropdown.options.IndexOf(extraStage.MissionDropdown.options.Find(s => s.text == extraStageData.missionString));

        extraStage.StageDropdown.onValueChanged.AddListener((value) => UpdateMissionDropdown(extraStage));

        extraStage.DeleteButton.onClick.AddListener(() => OnExtraStageDeleteButtonPressed(extraStage));

        ExtraStages.Add(extraStage);
    }
}
