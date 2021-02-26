using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class TrackerManager : MonoBehaviour
{
    //Path Tracker Variables
    int numOfPaths = 0;

    public PercentageDisplayManager PercentageDisplayManager;

    public PathViewerControl PathControl;

    public LayoutManager LayoutManager;

    [HideInInspector]
    public string storedFilePath = string.Empty;

    //Key Tracker Variables
    int numOfKeys = 0;
    private bool KeyEditMode = false;

    int numOfWeapons = 0;

    //A Rank Tracker Variables
    List<ThreeMissionControl> ThreeMissionLevels = new List<ThreeMissionControl>();
    List<TwoMissionControl> TwoMissionLevels = new List<TwoMissionControl>();
    List<BossControl> EndBosses = new List<BossControl>();
    int totalMissionsCompleted = 0;

    #region Mission and Boss Controls
    public MissionControl WestopolisControl;

    public MissionControl DigitalCircuitControl;
    public MissionControl GlyphicCanyonControl;
    public MissionControl LethalHighwayControl;

    public MissionControl CrypticCastleControl;
    public MissionControl PrisonIslandControl;
    public MissionControl CircusParkControl;

    public MissionControl CentralCityControl;
    public MissionControl TheDoomControl;
    public MissionControl SkyTroopsControl;
    public MissionControl MadMatrixControl;
    public MissionControl DeathRuinsControl;

    public MissionControl TheARKControl;
    public MissionControl AirFleetControl;
    public MissionControl IronJungleControl;
    public MissionControl SpaceGadgetControl;
    public MissionControl LostImpactControl;

    public MissionControl GUNFortressControl;
    public MissionControl BlackCometControl;
    public MissionControl LavaShelterControl;
    public MissionControl CosmicFallControl;
    public MissionControl FinalHauntControl;

    public MissionControl TheLastWayControl;

    //MidBosses
    public List<BossControl> Bosses = new List<BossControl>();

    public BossControl SonicAndDiablonPureDarkControl;
    public BossControl BlackDoomPureDarkControl;
    public BossControl SonicAndDiablonDarkControl;
    public BossControl EggDealerDarkControl;
    public BossControl EggDealerNormalDarkControl;
    public BossControl EggDealerNormalHeroControl;
    public BossControl EggDealerHeroControl;
    public BossControl BlackDoomHeroControl;
    public BossControl SonicAndDiablonPureHeroControl;
    public BossControl BlackDoomPureHeroControl;
    public BossControl DevilDoomControl;

    #endregion

    // Use this for initialization
    void Start ()
    {
        Common.InitalizeLevelData();
        Common.InitializeSaveFolder();
        if (!string.IsNullOrEmpty(Common.XShadowProfileLocation))
        {
            Common.ShadowProfileData = new XShadowProfileData(Common.XShadowProfileLocation);
        }

        ThreeMissionLevels = new List<ThreeMissionControl> { (ThreeMissionControl)WestopolisControl,
                                                             (ThreeMissionControl)GlyphicCanyonControl,
                                                             (ThreeMissionControl)CrypticCastleControl,
                                                             (ThreeMissionControl)PrisonIslandControl,
                                                             (ThreeMissionControl)CircusParkControl,
                                                             (ThreeMissionControl)TheDoomControl,
                                                             (ThreeMissionControl)SkyTroopsControl,
                                                             (ThreeMissionControl)MadMatrixControl,
                                                             (ThreeMissionControl)AirFleetControl,
                                                             (ThreeMissionControl)IronJungleControl,
                                                             (ThreeMissionControl)SpaceGadgetControl };

        TwoMissionLevels = new List<TwoMissionControl> { (TwoMissionControl)DigitalCircuitControl,
                                                         (TwoMissionControl)LethalHighwayControl,
                                                         (TwoMissionControl)CentralCityControl,
                                                         (TwoMissionControl)DeathRuinsControl,
                                                         (TwoMissionControl)TheARKControl,
                                                         (TwoMissionControl)LostImpactControl,
                                                         (TwoMissionControl)GUNFortressControl,
                                                         (TwoMissionControl)BlackCometControl,
                                                         (TwoMissionControl)LavaShelterControl,
                                                         (TwoMissionControl)CosmicFallControl,
                                                         (TwoMissionControl)FinalHauntControl };

        EndBosses = new List<BossControl> { SonicAndDiablonPureDarkControl,
                                            BlackDoomPureDarkControl,
                                            SonicAndDiablonDarkControl,
                                            EggDealerDarkControl,
                                            EggDealerNormalDarkControl,
                                            EggDealerNormalHeroControl,
                                            EggDealerHeroControl,
                                            BlackDoomHeroControl,
                                            SonicAndDiablonPureHeroControl,
                                            BlackDoomPureHeroControl,
                                            DevilDoomControl};

        //StartCoroutine("LoadFileFirstTime");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            LayoutManager.SwitchLayout();
        }

        if (LayoutManager.LayoutIndex == 0)
        {
            //Path Options
            if (Input.GetKeyUp(KeyCode.P))
            {
                togglePathMenu();
            }

            //Set All Missions and Keys to Obtained
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    setObtainAllNonPathItems();
            //}

            //Open Keys Menu
            if (Input.GetKeyUp(KeyCode.K))
            {
                toggleKeyMenu();
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                showRemainingMission();
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                toggleRoutingView();
            }

            //Return to Main Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LayoutManager.MenuCamera.enabled = !LayoutManager.MenuCamera.enabled;
                LayoutManager.MenuCanvas.enabled = !LayoutManager.MenuCanvas.enabled;
            }
        }
        updateARanks();

        updateKeys();

        updateWeapons();

        updatePaths();

        PercentageDisplayManager.UpdateTrackerTextObjects(totalMissionsCompleted, numOfKeys, numOfWeapons, numOfPaths);
    }

    void updateARanks()
    {
        totalMissionsCompleted = 0;
        totalMissionsCompleted += checkThreeMissionLevelsComplete();
        totalMissionsCompleted += checkTwoMissionLevelsComplete();
        totalMissionsCompleted += checkBossesComplete();
    }

    void updateKeys()
    {
        numOfKeys = 0;
        
        foreach (var level in ThreeMissionLevels)
        {
            numOfKeys += level.NumOfKeys;
        }

        foreach (var level in TwoMissionLevels)
        {
            numOfKeys += level.NumOfKeys;
        }

        numOfKeys += TheLastWayControl.NumOfKeys;
    }

    void updateWeapons()
    {
        numOfWeapons = 0;

        foreach (var endBoss in EndBosses)
        {
            if (endBoss.BossComplete.enabled)
            {
                numOfWeapons++;
            }
        }
    }

    void updatePaths()
    {
        numOfPaths = 0;
        foreach (PathControlItem path in PathControl.Paths)
        {
            if (path.CompletedToggle.isOn)
            {
                numOfPaths++;
            }
        }
    }

    private IEnumerator LoadFileFirstTime()
    {
        while (PathControl.numOfPaths != 326)
        {
            yield return new WaitForSeconds(0.5f);
        }
        LoadData();
    }

    private void SaveData()
    {
        if (!string.IsNullOrEmpty(storedFilePath))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(storedFilePath))
            {
                foreach (var path in PathControl.Paths)
                {
                    sw.WriteLine(path.CompletedToggle.isOn);
                }
            }
        }
    }

    private void LoadData()
    {
        if (File.Exists(storedFilePath))
        {
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(storedFilePath))
            {
                string s = "";
                foreach (var path in PathControl.Paths)
                {
                    if ((s = sr.ReadLine()) != null)
                    {
                        path.CompletedToggle.isOn = bool.Parse(s);
                    }
                }
            }
        }
    }

    void showRemainingMission()
    {
        foreach (var level in ThreeMissionLevels)
        {
            level.ResetRemaining();
            level.ShowRemainingText(!level.RemainingDarkText.enabled);
        }

        foreach (var level in TwoMissionLevels)
        {
            level.ResetRemaining();
            level.ShowRemainingText(!level.RemainingDarkText.enabled);
        }

        foreach (var path in PathControl.Paths.Where(p => !p.CompletedToggle.isOn).ToList())
        {
            for (int i = 0; i < path.LevelsInPath.Count - 1; i++)
            {
                var level = path.LevelsInPath[i];

                if (level.NextLevelHero != null && level.LevelControl != null)
                {
                    if (level.NextLevelHero.Equals(path.LevelsInPath[i + 1]))
                    {
                        level.LevelControl.RemainingHeroPlays++;
                    }
                }
                if (level.NextLevelNeutral != null && level.LevelControl != null)
                {
                    if (level.NextLevelNeutral.Equals(path.LevelsInPath[i + 1]))
                    {
                        level.LevelControl.RemainingNeutralPlays++;
                    }
                }
                if (level.NextLevelDark != null && level.LevelControl != null)
                {
                    if (level.NextLevelDark.Equals(path.LevelsInPath[i + 1]))
                    {
                        level.LevelControl.RemainingDarkPlays++;
                    }
                }
            }
        }

        foreach (var level in ThreeMissionLevels)
        {
            level.UpdateRemainingText();
        }

        foreach (var level in TwoMissionLevels)
        {
            level.UpdateRemainingText();
        }
    }

    int checkThreeMissionLevelsComplete()
    {
        int missionsCompleted = 0;
        foreach (var mission in ThreeMissionLevels)
        {
            if (mission.DarkComplete.enabled)
            {
                missionsCompleted++;
            }
            if (mission.NeutralComplete.enabled)
            {
                missionsCompleted++;
            }
            if (mission.HeroComplete.enabled)
            {
                missionsCompleted++;
            }
        }

        return missionsCompleted;
    }

    int checkTwoMissionLevelsComplete()
    {
        int missionsCompleted = 0;
        foreach (var mission in TwoMissionLevels)
        {
            switch (mission.Mode)
            {
                case TwoMissionControl.TwoMissionMode.DarkHeroTop:
                case TwoMissionControl.TwoMissionMode.DarkHeroBottom:
                case TwoMissionControl.TwoMissionMode.DarkHeroLast:
                    if (mission.DarkComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    if (mission.HeroComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    break;
                case TwoMissionControl.TwoMissionMode.DarkNeutral:
                    if (mission.DarkComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    if (mission.NeutralDarkComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    break;
                case TwoMissionControl.TwoMissionMode.NeutralHero:
                    if (mission.NeutralHeroComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    if (mission.HeroComplete.enabled)
                    {
                        missionsCompleted++;
                    }
                    break;
            }
        }

        return missionsCompleted;
    }

    int checkBossesComplete()
    {
        int missionsCompleted = 0;

        foreach (var boss in Bosses)
        {
            if (boss.BossComplete.enabled)
            {
                missionsCompleted++;
            }
        }

        if (SonicAndDiablonPureDarkControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (BlackDoomPureDarkControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (SonicAndDiablonDarkControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (EggDealerDarkControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (EggDealerNormalDarkControl.BossComplete.enabled || EggDealerNormalHeroControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (EggDealerHeroControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (BlackDoomHeroControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (SonicAndDiablonPureHeroControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        if (BlackDoomPureHeroControl.BossComplete.enabled)
        {
            missionsCompleted++;
        }

        return missionsCompleted;
    }

    void setObtainAllNonPathItems()
    {
        foreach (var level in ThreeMissionLevels)
        {
            level.SetAllComplete();
            level.NumOfKeys = 5;
        }

        foreach (var level in TwoMissionLevels)
        {
            level.SetAllComplete();
            level.NumOfKeys = 5;
        }

        TheLastWayControl.NumOfKeys = 5;

        foreach (var boss in Bosses)
        {
            boss.BossComplete.enabled = true;
        }       
    }

    void toggleKeyMenu()
    {
        LayoutManager.KeysCamera.enabled = !LayoutManager.KeysCamera.enabled;
        LayoutManager.KeysCanvas.enabled = !LayoutManager.KeysCanvas.enabled;

        //KeyEditMode = !KeyEditMode;
        //foreach (var level in ThreeMissionLevels)
        //{
        //    level.KeyEditMode.SetActive(KeyEditMode);
        //    level.SetPathActives(!KeyEditMode);
        //}

        //foreach (var level in TwoMissionLevels)
        //{
        //    level.KeyEditMode.SetActive(KeyEditMode);
        //    level.SetPathActives(!KeyEditMode);
        //}

        //TheLastWayControl.KeyEditMode.SetActive(KeyEditMode);
        //TheLastWayControl.SetPathActives(!KeyEditMode);
    }

    void toggleRoutingView()
    {
        LayoutManager.RoutingCamera.enabled = !LayoutManager.RoutingCamera.enabled;
        LayoutManager.RoutingCanvas.enabled = !LayoutManager.RoutingCanvas.enabled;
    }

    void togglePathMenu()
    { 
        LayoutManager.PathMenuCamera.enabled = !LayoutManager.PathMenuCamera.enabled;
        LayoutManager.PathMenuCanvas.enabled = !LayoutManager.PathMenuCanvas.enabled;
    }
}
