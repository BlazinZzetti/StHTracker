using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageDisplayManager : MonoBehaviour
{
    public Text ARankTrackerText;
    public Text KeyTrackerText;
    public Text WeaponsTrackerText;
    public Text PathTrackerText;
    public Text TotalTrackerText;
    public Text EstimatedTrackerText;

    public Toggle ARanksToggle;
    public Toggle KeysToggle;
    public Toggle WeaponsToggle;
    public Toggle PathsToggle;
    public Toggle TotalToggle;
    public Toggle EstToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTrackersEnabled();
    }

    void updateTrackersEnabled()
    {
        ARankTrackerText.enabled = ARanksToggle.isOn;
        KeyTrackerText.enabled = KeysToggle.isOn;
        WeaponsTrackerText.enabled = WeaponsToggle.isOn;
        PathTrackerText.enabled = PathsToggle.isOn;
        TotalTrackerText.enabled = TotalToggle.isOn;

        EstimatedTrackerText.enabled = EstToggle.isOn;
        EstimatedTrackerText.transform.GetChild(0).gameObject.SetActive(EstToggle.isOn);
    }

    public void UpdateTrackerTextObjects(int currentARanks, int currentKeys, int currentWeapons, int currentPaths)
    {
        //Estimated Tracker Weights
        var totalPaths = 326 * 4;

        ARankTrackerText.text = "A Ranks: " + currentARanks + " / 71 " + ((currentARanks / 71.0f) * 100).ToString("f2") + "%";
        KeyTrackerText.text = "Keys: " + currentKeys + " / 115 " + ((currentKeys / 115.0f) * 100).ToString("f2") + "%";
        WeaponsTrackerText.text = "Weapons: " + currentWeapons + " / 11 " + ((currentWeapons / 11.0f) * 100).ToString("f2") + "%";
        PathTrackerText.text = "Paths: " + currentPaths + " / 326 " + ((currentPaths / 326.0f) * 100).ToString("f2") + "%";

        var currentViewableTotal = ((ARanksToggle.isOn) ? currentARanks : 0)
                                + ((KeysToggle.isOn) ? currentKeys : 0)
                                + ((WeaponsToggle.isOn) ? currentWeapons : 0)
                                + ((PathsToggle.isOn) ? currentPaths : 0);

        float currentViewableTotalMax = ((ARanksToggle.isOn) ? 71 : 0)
                                + ((KeysToggle.isOn) ? 115 : 0)
                                + ((WeaponsToggle.isOn) ? 11 : 0)
                                + ((PathsToggle.isOn) ? 326 : 0);

        TotalTrackerText.text = "Total: " + currentViewableTotal + " / " + currentViewableTotalMax + " " + ((currentViewableTotal / currentViewableTotalMax) * 100).ToString("f2") + "%";
        EstimatedTrackerText.text = (((currentARanks + (currentKeys) + (currentPaths * 4)) / (float)(71 + 115 + totalPaths)) * 100).ToString("f2") + "%";
    }
}
