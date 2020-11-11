using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using UnityApplication = UnityEngine.Application;

public class PathRoutingManager : MonoBehaviour
{
    public Button AddPathButton;
    public Button ClearPathsButton;
    public Button OpenRouteButton;
    public Button SaveRouteButton;
    public Button CalculateButton;
    public Button ExtraStagesButton;

    public Toggle NewGameToggle;
    public Toggle NoCCGToggle;

    public GameObject RoutingPathObjectContainer;

    public GameObject OutputPanel;
    public Button OutputPanelCloseButton;
    public Text OutputText;
    private string unableToCompleteRoute = null;

    Dictionary<char, ProfileLevel.MissionType> MisionTypeLookup = new Dictionary<char, ProfileLevel.MissionType>
        {
            { 'D', ProfileLevel.MissionType.Dark },
            { 'N', ProfileLevel.MissionType.Normal },
            { 'H', ProfileLevel.MissionType.Hero },
        };

    public List<RoutingPathObject> RoutingPaths = new List<RoutingPathObject>();

    private List<CutsceneData> CutsceneData = new List<CutsceneData>();

    public GameObject SavedRouteSelectionPanel;
    public Button SavedRouteSelectionPanelCloseButton;
    public ScrollRect SavedRouteSelectionPanelScrollView;

    public ExtraStageManager ExtraStagesPanel;

    public GameObject SaveMessageOverwritePanel;
    public Text SaveMessageOverwriteFileNameText;
    public Button SaveMessageOverwritePanelYesButton;
    public Button SaveMessageOverwritePanelNewFileButton;
    public Button SaveMessageOverwritePanelCancelButton;

    public GameObject NewFileSavePanel;
    public InputField NewFileSaveInputField;
    public Button NewFileSavePanelYesButton;
    public Button NewFileSavePanelCancelButton;

    public GameObject FileExistsOverwritePanel;
    public Text FileExistsOverwriteFileNameText;
    public Button FileExistsOverwritePanelYesButton;
    public Button FileExistsOverwritePanelCancelButton;

    public PathSettingsControl PathSettingsControlPanel;

    private string lastLoadedSaveFile;

    public List<RouteSaveFileObject> RoutingSaveFiles = new List<RouteSaveFileObject>();

    #region RoutingLevels
    RoutingLevel SonicDiablonPD;
    RoutingLevel BlackDoomPD;
    RoutingLevel SonicDiablonD;

    RoutingLevel EggDealerD;
    RoutingLevel EggDealerND;
    RoutingLevel EggDealerNH;
    RoutingLevel EggDealerH;

    RoutingLevel BlackDoomH;
    RoutingLevel SonicDiablonPH;
    RoutingLevel BlackDoomPH;

    RoutingLevel GUNFortress;
    RoutingLevel BlackComet;
    RoutingLevel LavaShelter;
    RoutingLevel CosmicFall;
    RoutingLevel FinalHaunt;

    RoutingLevel TheARK;
    RoutingLevel AirFleet;
    RoutingLevel IronJungle;
    RoutingLevel SpaceGadget;
    RoutingLevel LostImpact;

    RoutingLevel CentralCity;
    RoutingLevel TheDoom;
    RoutingLevel SkyTroops;
    RoutingLevel MadMatrix;
    RoutingLevel DeathRuins;

    RoutingLevel CrypticCastle;
    RoutingLevel PrisonIsland;
    RoutingLevel CircusPark;

    RoutingLevel DigitalCircuit;
    RoutingLevel GlyphicCanyon;
    RoutingLevel LethalHighway;

    RoutingLevel Westopolis;

    List<RoutingLevel> AllRoutingLevels;
    #endregion

    public List<string> PathCodeByNumber;

    UnlockableWeapons weaponStatus = new UnlockableWeapons();

    void Awake()
    {
        Common.InitializeSaveFolder();
        Common.LoadConfigFile();
        initializeCutsceneData();
        initializeRoutingLevels();
        initializePathCodesByNumber();

        refreshSavedRouteFiles();

        AllRoutingLevels = new List<RoutingLevel>()
        {
            GUNFortress,
            BlackComet,
            LavaShelter,
            CosmicFall,
            FinalHaunt,

            TheARK,
            AirFleet,
            IronJungle,
            SpaceGadget,
            LostImpact,

            CentralCity,
            TheDoom,
            SkyTroops,
            MadMatrix,
            DeathRuins,

            CrypticCastle,
            PrisonIsland,
            CircusPark,

            DigitalCircuit,
            GlyphicCanyon,
            LethalHighway,

            Westopolis,
        };

        NewGameToggle.isOn = false;
        NoCCGToggle.isOn = false;
        OutputText.text = "";

        AddPathButton.onClick.AddListener(addRoutingPath);
        ClearPathsButton.onClick.AddListener(clearRoutingPaths);
        CalculateButton.onClick.AddListener(calculatePaths);

        OpenRouteButton.onClick.AddListener(openSavedRoutesSelection);
        SavedRouteSelectionPanelCloseButton.onClick.AddListener(closeSavedRoutesSelection);

        ExtraStagesButton.onClick.AddListener(openExtraStages);
        ExtraStagesPanel.CloseButton.onClick.AddListener(closeExtraStages);

        SaveRouteButton.onClick.AddListener(saveCurrentRoute);

        OutputPanelCloseButton.onClick.AddListener(closeOutputPanel);
    }

    void Start()
    {
        //Check to see if there are any routes in the routes folder.
        OpenRouteButton.interactable = true;

        addRoutingPath();
    }

    // Update is called once per frame
    void Update()
    {
        adjustSavedRouteSelectionViewSize();
        adjustExtraStagesSelectionViewSize();
    }

    private void initializeCutsceneData()
    {
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
        CutsceneData.Add(new CutsceneData(10, 5));
    }

    private void initializeRoutingLevels()
    {
        SonicDiablonPD = new RoutingLevel("Sonic Diablon PD", null, null, null);
        BlackDoomPD = new RoutingLevel("Black Doom PD", null, null, null);
        SonicDiablonD = new RoutingLevel("Sonic Diablon D", null, null, null);
                                    
        EggDealerD = new RoutingLevel("Egg Dealer D", null, null, null);
        EggDealerND = new RoutingLevel("Egg Dealer ND", null, null, null);
        EggDealerNH = new RoutingLevel("Egg Dealer NH", null, null, null);
        EggDealerH = new RoutingLevel("Egg Dealer H", null, null, null);
                                      
        BlackDoomH = new RoutingLevel("Black Doom H", null, null, null);
        SonicDiablonPH = new RoutingLevel("Sonic Diablon PH", null, null, null);
        BlackDoomPH = new RoutingLevel("Black Doom PH", null, null, null);
                                        
        GUNFortress = new RoutingLevel("GUN Fortress", SonicDiablonPD, null, BlackDoomPD);
        BlackComet = new RoutingLevel("Black Comet", SonicDiablonD, null, EggDealerD);
        LavaShelter = new RoutingLevel("Lava Shelter", EggDealerND, null, EggDealerNH);
        CosmicFall = new RoutingLevel("Cosmic Fall", BlackDoomH, null, EggDealerH);
        FinalHaunt = new RoutingLevel("Final Haunt", SonicDiablonPH, null, BlackDoomPH);
                                      
        TheARK = new RoutingLevel("The ARK", GUNFortress, BlackComet, null);
        AirFleet = new RoutingLevel("Air Fleet", GUNFortress, BlackComet, LavaShelter);
        IronJungle = new RoutingLevel("Iron Jungle", BlackComet, LavaShelter, CosmicFall);
        SpaceGadget = new RoutingLevel("Space Gadget", LavaShelter, CosmicFall, FinalHaunt);
        LostImpact = new RoutingLevel("Lost Impact", null, CosmicFall, FinalHaunt);
                                       
        CentralCity = new RoutingLevel("Central City", TheARK, null, AirFleet);
        TheDoom = new RoutingLevel("The Doom", TheARK, AirFleet, IronJungle);
        SkyTroops = new RoutingLevel("Sky Troops", AirFleet, IronJungle, SpaceGadget);
        MadMatrix = new RoutingLevel("Mad Matrix", IronJungle, SpaceGadget, LostImpact);
        DeathRuins = new RoutingLevel("Death Ruins", SpaceGadget, null, LostImpact);
                                        
        CrypticCastle =  new RoutingLevel("Cryptic Castle", CentralCity, TheDoom, SkyTroops);
        PrisonIsland = new RoutingLevel("Prison Island", TheDoom, SkyTroops, MadMatrix);
        CircusPark = new RoutingLevel("Circus Park", SkyTroops, MadMatrix, DeathRuins);
                                       
        DigitalCircuit = new RoutingLevel("Digital Circuit", CrypticCastle, null, PrisonIsland);
        GlyphicCanyon =  new RoutingLevel("Glyphic Canyon", CrypticCastle, PrisonIsland, CircusPark);
        LethalHighway = new RoutingLevel("Lethal Highway", PrisonIsland, null, CircusPark);
                                        
        Westopolis = new RoutingLevel("Westopolis", DigitalCircuit, GlyphicCanyon, LethalHighway);

        Westopolis.DarkCutscenes = new List<int>() { 0, 12 };
        Westopolis.NormalCutscenes = new List<int>() { 0, 1, 2 };
        Westopolis.HeroCutscenes = new List<int>() { 0, 26 };
        DigitalCircuit.DarkCutscenes = new List<int>() { 3, 13 };
        DigitalCircuit.HeroCutscenes = new List<int>() { 3, 4 };
        LethalHighway.DarkCutscenes = new List<int>() { 27, 3, 4 };
        LethalHighway.HeroCutscenes = new List<int>() { 27, 3, 28 };
        GlyphicCanyon.DarkCutscenes = new List<int>() { 3, 13 };
        GlyphicCanyon.NormalCutscenes = new List<int>() { 3, 4 };
        GlyphicCanyon.HeroCutscenes = new List<int>() { 3, 28 };
        CrypticCastle.DarkCutscenes = new List<int>() { 14, 15, 16 };
        CrypticCastle.NormalCutscenes = new List<int>() { 14, 57 };
        CrypticCastle.HeroCutscenes = new List<int>() { 14, 5, 6 };
        PrisonIsland.DarkCutscenes = new List<int>() { 46 };
        PrisonIsland.NormalCutscenes = new List<int>() { 5, 6 };
        PrisonIsland.HeroCutscenes = new List<int>() { 38 };
        CircusPark.DarkCutscenes = new List<int>() { 5, 6 };
        CircusPark.NormalCutscenes = new List<int>() { 38 };
        CircusPark.HeroCutscenes = new List<int>() { 29 };
        CentralCity.DarkCutscenes = new List<int>() { 17 };
        CentralCity.HeroCutscenes = new List<int>() { 48 };
        TheDoom.DarkCutscenes = new List<int>() { 47, 17 };
        TheDoom.NormalCutscenes = new List<int>() { 47, 48 };
        TheDoom.HeroCutscenes = new List<int>() { 47, 7 };
        SkyTroops.DarkCutscenes = new List<int>() { 48 };
        SkyTroops.NormalCutscenes = new List<int>() { 7 };
        SkyTroops.HeroCutscenes = new List<int>() { 31, 40 };
        MadMatrix.DarkCutscenes = new List<int>() { 39, 7 };
        MadMatrix.NormalCutscenes = new List<int>() { 39, 31, 40 };
        MadMatrix.HeroCutscenes = new List<int>() { 39, 31, 32, 33 };
        DeathRuins.DarkCutscenes = new List<int>() { 30, 31, 40 };
        DeathRuins.HeroCutscenes = new List<int>() { 30, 31, 32, 33 };
        TheARK.DarkCutscenes = new List<int>() { 18, 19, 20, 21, 22, 23 };
        TheARK.NormalCutscenes = new List<int>() { 18, 19, 20, 21, 67, 50 };
        AirFleet.DarkCutscenes = new List<int>() { 23 };
        AirFleet.NormalCutscenes = new List<int>() { 49, 50 };
        AirFleet.HeroCutscenes = new List<int>() { 53 };
        IronJungle.DarkCutscenes = new List<int>() { 8, 60, 50 };
        IronJungle.NormalCutscenes = new List<int>() { 8, 9 };
        IronJungle.HeroCutscenes = new List<int>() { 8, 41, 42, 43 };
        SpaceGadget.DarkCutscenes = new List<int>() { 56 };
        SpaceGadget.NormalCutscenes = new List<int>() { 41, 42, 43 };
        SpaceGadget.HeroCutscenes = new List<int>() { 34, 35 };
        LostImpact.NormalCutscenes = new List<int>() { 41, 42, 43 };
        LostImpact.HeroCutscenes = new List<int>() { 34, 35 };
        GUNFortress.DarkCutscenes = new List<int>() { 24, 25 };
        GUNFortress.HeroCutscenes = new List<int>() { 63, 64 };
        BlackComet.DarkCutscenes = new List<int>() { 61, 62 };
        BlackComet.HeroCutscenes = new List<int>() { 51, 52 };
        LavaShelter.DarkCutscenes = new List<int>() { 54, 55 };
        LavaShelter.HeroCutscenes = new List<int>() { 10, 11 };
        CosmicFall.DarkCutscenes = new List<int>() { 58, 59 };
        CosmicFall.HeroCutscenes = new List<int>() { 44, 45 };
        FinalHaunt.DarkCutscenes = new List<int>() { 65, 66 };
        FinalHaunt.HeroCutscenes = new List<int>() { 36, 37 };
    }

    private void initializePathCodesByNumber()
    {
        PathCodeByNumber = new List<string>();
        LevelSearch(Westopolis, null);
    }

    public void LevelSearch(RoutingLevel level, List<RoutingLevel> LevelPath)
    {
        if (LevelPath == null)
        {
            LevelPath = new List<RoutingLevel>();
        }
        LevelPath.Add(level);
        switch (level.levelMode)
        {
            case RoutingLevel.LevelMode.AllMissions:
                if (level.DarkEndingDestination != null)
                {
                    LevelSearch(level.DarkEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                if (level.NormalEndingDestination != null)
                {
                    LevelSearch(level.NormalEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                if (level.HeroEndingDestination != null)
                {
                    LevelSearch(level.HeroEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                break;
            case RoutingLevel.LevelMode.DarkNeutral:
                if (level.DarkEndingDestination != null)
                {
                    LevelSearch(level.DarkEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                if (level.NormalEndingDestination != null)
                {
                    LevelSearch(level.NormalEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                break;
            case RoutingLevel.LevelMode.HeroDark:
                if (level.DarkEndingDestination != null)
                {
                    LevelSearch(level.DarkEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                if (level.HeroEndingDestination != null)
                {
                    LevelSearch(level.HeroEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                break;
            case RoutingLevel.LevelMode.HeroNeutral:
                if (level.NormalEndingDestination != null)
                {
                    LevelSearch(level.NormalEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                if (level.HeroEndingDestination != null)
                {
                    LevelSearch(level.HeroEndingDestination, LevelPath);
                    LevelPath.Remove(LevelPath[LevelPath.Count - 1]);
                }
                else
                {
                    Debug.LogError("levelMode failed.");
                }
                break;
            case RoutingLevel.LevelMode.FinalLevel:
                AddPathCode(LevelPath);
                break;
            default:
                break;

        }
    }

    public void AddPathCode(List<RoutingLevel> LevelPath)
    {
        string PathCode = "";
        for (int i = 0; i < LevelPath.Count - 1; i++)
        {
            if (LevelPath[i].DarkEndingDestination != null && LevelPath[i].DarkEndingDestination.Equals(LevelPath[i + 1]))
            {
                PathCode += "D";
            }
            if (LevelPath[i].NormalEndingDestination != null && LevelPath[i].NormalEndingDestination.Equals(LevelPath[i + 1]))
            {
                PathCode += "N";
            }
            if (LevelPath[i].HeroEndingDestination != null && LevelPath[i].HeroEndingDestination.Equals(LevelPath[i + 1]))
            {
                PathCode += "H";
            }
        }

        PathCodeByNumber.Add(PathCode);
    }

    private void refreshSavedRouteFiles()
    {
        var xShadowRouteFiles = Directory.GetFiles(Common.SavedRoutesFolderPath, "*.xshadowroute");
        int numberOfFiles = xShadowRouteFiles.Length;

        foreach (var saveFile in RoutingSaveFiles)
        {
            Destroy(saveFile.gameObject);
        }
        RoutingSaveFiles.Clear();

        for (int i = 0; i < numberOfFiles; i++)
        {
            var routingSaveFile = Instantiate(Resources.Load("RouteSaveFileObject")) as GameObject;
            RouteSaveFileObject RoutingSaveFile = routingSaveFile.GetComponent<RouteSaveFileObject>();
            if (RoutingSaveFile.Setup(xShadowRouteFiles[i]))
            {
                routingSaveFile.transform.SetParent(SavedRouteSelectionPanelScrollView.content, false);

                RoutingSaveFile.OpenButton.onClick.AddListener(() => OnRouteSaveFileOpenButtonPressed(RoutingSaveFile));
                RoutingSaveFile.DeleteButton.onClick.AddListener(() => OnRouteSaveFileDeleteButtonPressed(RoutingSaveFile));

                RoutingSaveFiles.Add(RoutingSaveFile);
            }
            else
            {
                Destroy(routingSaveFile);
            }
        }
    }

    private void addRoutingPath()
    {
        var routingPathObject = Instantiate(Resources.Load("RoutingPathObject")) as GameObject;
        RoutingPathObject routingPath = routingPathObject.GetComponent<RoutingPathObject>();
        routingPath.PathData = new RoutingPathData();
        routingPath.transform.SetParent(RoutingPathObjectContainer.transform, false);

        routingPath.UpButton.onClick.AddListener(() => OnRoutingPathUpButtonPressed(routingPath));
        routingPath.DownButton.onClick.AddListener(() => OnRoutingPathDownButtonPressed(routingPath));
        routingPath.DeleteButton.onClick.AddListener(() => OnRoutingPathDeleteButtonPressed(routingPath));
        routingPath.SettingsButton.onClick.AddListener(() => ShowPathSettingsControlPanel(routingPath));

        routingPath.PathInputField.onEndEdit.AddListener(delegate { OnRoutingPathInputFieldEditEnd(routingPath); });

        RoutingPaths.Add(routingPath);

        refreshInterface();
    }

    private void addRoutingPath(RoutingPathData rpd)
    {
        var routingPathObject = Instantiate(Resources.Load("RoutingPathObject")) as GameObject;
        RoutingPathObject routingPath = routingPathObject.GetComponent<RoutingPathObject>();
        routingPath.Setup(rpd);
        routingPath.transform.SetParent(RoutingPathObjectContainer.transform, false);

        routingPath.UpButton.onClick.AddListener(() => OnRoutingPathUpButtonPressed(routingPath));
        routingPath.DownButton.onClick.AddListener(() => OnRoutingPathDownButtonPressed(routingPath));
        routingPath.DeleteButton.onClick.AddListener(() => OnRoutingPathDeleteButtonPressed(routingPath));
        routingPath.SettingsButton.onClick.AddListener(() => ShowPathSettingsControlPanel(routingPath));

        routingPath.PathInputField.onEndEdit.AddListener(delegate { OnRoutingPathInputFieldEditEnd(routingPath); });

        RoutingPaths.Add(routingPath);
    }

    private void clearRoutingPaths()
    {
        foreach (var path in RoutingPaths)
        {
            Destroy(path.gameObject);
        }
        RoutingPaths.Clear();

        addRoutingPath();
    }

    private void adjustSavedRouteSelectionViewSize()
    {
        SavedRouteSelectionPanelScrollView.content.sizeDelta
            = new Vector2(SavedRouteSelectionPanelScrollView.content.sizeDelta.x, SavedRouteSelectionPanelScrollView.content.childCount * 30);
    }

    private void adjustExtraStagesSelectionViewSize()
    {
        ExtraStagesPanel.content.sizeDelta
            = new Vector2(ExtraStagesPanel.content.sizeDelta.x, ExtraStagesPanel.content.childCount * 50);
    }

    private void openSavedRoutesSelection()
    {
        refreshSavedRouteFiles();
        SavedRouteSelectionPanel.SetActive(true);
    }

    private void closeSavedRoutesSelection()
    {
        SavedRouteSelectionPanel.SetActive(false);
    }

    private void openExtraStages()
    {
        ExtraStagesPanel.gameObject.SetActive(true);
    }

    private void closeExtraStages()
    {
        ExtraStagesPanel.gameObject.SetActive(false);
    }

    private void saveCurrentRoute()
    {
        if (!string.IsNullOrEmpty(lastLoadedSaveFile))
        {
            //Check if they want to overwrite the loaded save.
            ShowSaveMessageOverwritePanel();
        }
        else
        {
            ShowNewFileSavePanel();
        }
    }

    private void ShowSaveMessageOverwritePanel()
    {
        SaveMessageOverwritePanelYesButton.onClick.RemoveAllListeners();
        SaveMessageOverwritePanelNewFileButton.onClick.RemoveAllListeners();
        SaveMessageOverwritePanelCancelButton.onClick.RemoveAllListeners();

        SaveMessageOverwriteFileNameText.text = Path.GetFileName(lastLoadedSaveFile).Replace(".xshadowroute", "");

        SaveMessageOverwritePanelYesButton.onClick.AddListener(() => { saveCurrentRouteToFile(lastLoadedSaveFile); SaveMessageOverwritePanel.SetActive(false); });
        SaveMessageOverwritePanelNewFileButton.onClick.AddListener(() => { ShowNewFileSavePanel(); SaveMessageOverwritePanel.SetActive(false); });
        SaveMessageOverwritePanelCancelButton.onClick.AddListener(() => SaveMessageOverwritePanel.SetActive(false));

        SaveMessageOverwritePanel.SetActive(true);
    }

    private void ShowNewFileSavePanel()
    {
        NewFileSavePanelYesButton.onClick.RemoveAllListeners();
        NewFileSavePanelCancelButton.onClick.RemoveAllListeners();

        NewFileSavePanelYesButton.onClick.AddListener(() => { attemptToSaveNewFile(NewFileSaveInputField.text); NewFileSavePanel.SetActive(false); });
        NewFileSavePanelCancelButton.onClick.AddListener(() => NewFileSavePanel.SetActive(false));

        NewFileSavePanel.SetActive(true);
    }

    private void attemptToSaveNewFile(string newFileName)
    {
        var filePathToSave = Common.SavedRoutesFolderPath + "\\" + newFileName + ".xshadowroute";
        if (File.Exists(filePathToSave))
        {
            ShowFileExistsOverwritePanel(filePathToSave);
        }
        else
        {
            saveCurrentRouteToFile(filePathToSave);
        }
    }

    private void ShowFileExistsOverwritePanel(string filePathToSave)
    {
        FileExistsOverwritePanelYesButton.onClick.RemoveAllListeners();
        FileExistsOverwritePanelCancelButton.onClick.RemoveAllListeners();

        FileExistsOverwriteFileNameText.text = Path.GetFileName(filePathToSave).Replace(".xshadowroute", "");

        FileExistsOverwritePanelYesButton.onClick.AddListener(() => { saveCurrentRouteToFile(filePathToSave); FileExistsOverwritePanel.SetActive(false); });
        FileExistsOverwritePanelCancelButton.onClick.AddListener(() => { FileExistsOverwritePanel.SetActive(false); ShowNewFileSavePanel(); });

        FileExistsOverwritePanel.SetActive(true);
    }

    private void saveCurrentRouteToFile(string filePath)
    {
        var xml = new XmlDocument();

        var baseNode = xml.CreateElement("Route");

        var NewGameNode = xml.CreateElement("NewGame");
        NewGameNode.InnerText = NewGameToggle.isOn.ToString();

        var NoCCGNode = xml.CreateElement("NoCCG");
        NoCCGNode.InnerText = NoCCGToggle.isOn.ToString();

        var favoriteNode = xml.CreateElement("Favorite");
        favoriteNode.InnerText = "false";

        var pathsNote = xml.CreateElement("Paths");
        foreach (var path in RoutingPaths)
        {
            var pathDataNote = xml.CreateElement("Path");
            pathDataNote.SetAttribute("number", path.PathData.ValidPathNumber.ToString());
            pathDataNote.SetAttribute("code", path.PathData.ValidPathCode);
            pathDataNote.SetAttribute("display", path.PathData.displayType.ToString());

            for (int i = 0; i < 6; i++)
            {
                var keysDataNote = xml.CreateElement("Keys");

                keysDataNote.SetAttribute("key1", path.PathData.StageKeys[i, 0].ToString());
                keysDataNote.SetAttribute("key2", path.PathData.StageKeys[i, 1].ToString());
                keysDataNote.SetAttribute("key3", path.PathData.StageKeys[i, 2].ToString());
                keysDataNote.SetAttribute("key4", path.PathData.StageKeys[i, 3].ToString());
                keysDataNote.SetAttribute("key5", path.PathData.StageKeys[i, 4].ToString());

                pathDataNote.AppendChild(keysDataNote);
            }

            pathsNote.AppendChild(pathDataNote);
        }

        var extraStagesNode = xml.CreateElement("ExtraStages");
        foreach (var extraStage in ExtraStagesPanel.ExtraStages)
        {
            var extraStageNote = xml.CreateElement("ExtraStage");
            extraStageNote.SetAttribute("level", Common.LevelNames[extraStage.StageDropdown.value]);
            extraStageNote.SetAttribute("mission", extraStage.MissionDropdown.options[extraStage.MissionDropdown.value].text);

            var keysDataNote = xml.CreateElement("Keys");

            keysDataNote.SetAttribute("key1", extraStage.Key1Toggle.isOn.ToString());
            keysDataNote.SetAttribute("key2", extraStage.Key2Toggle.isOn.ToString());
            keysDataNote.SetAttribute("key3", extraStage.Key3Toggle.isOn.ToString());
            keysDataNote.SetAttribute("key4", extraStage.Key4Toggle.isOn.ToString());
            keysDataNote.SetAttribute("key5", extraStage.Key5Toggle.isOn.ToString());

            extraStageNote.AppendChild(keysDataNote);
            extraStagesNode.AppendChild(extraStageNote);
        }

        baseNode.AppendChild(NewGameNode);
        baseNode.AppendChild(NoCCGNode);
        baseNode.AppendChild(favoriteNode);
        baseNode.AppendChild(pathsNote);
        baseNode.AppendChild(extraStagesNode);

        xml.AppendChild(baseNode);

        xml.Save(filePath);

        lastLoadedSaveFile = filePath;
    }

    private void closeOutputPanel()
    {
        OutputPanel.SetActive(false);
    }

    private void calculatePaths()
    {
        unableToCompleteRoute = null;
        weaponStatus = new UnlockableWeapons();

        if(NewGameToggle.isOn)
        {
            weaponStatus.GUNFortressDarkComplete();
            weaponStatus.GUNFortressHeroComplete();
            weaponStatus.BlackCometDarkComplete();
            weaponStatus.BlackCometHeroComplete();
            weaponStatus.LavaShelterDarkComplete();
            weaponStatus.LavaShelterHeroComplete();
            weaponStatus.CosmicFallDarkComplete();
            weaponStatus.CosmicFallHeroComplete();
            weaponStatus.FinalHauntDarkComplete();
            weaponStatus.FinalHauntHeroComplete();
        }

        foreach (var cs in CutsceneData)
        {
            cs.Skippable = NewGameToggle.isOn;
        }

        uint timeToComplete = 0;
        string outputString = string.Empty;

        if (Common.ShadowProfileData != null)
        {
            foreach (var rp in RoutingPaths)
            {
                var code = rp.PathData.ValidPathCode;
                uint timeToCompletePath = 0;

                RoutingLevel pointer = Westopolis;
                for (int i = 0; i < 6; i++)
                {
                    bool[] keys = new bool[]
                    {
                    rp.PathData.StageKeys[i,0],
                    rp.PathData.StageKeys[i,1],
                    rp.PathData.StageKeys[i,2],
                    rp.PathData.StageKeys[i,3],
                    rp.PathData.StageKeys[i,4]
                    };
                    switch (code[i])
                    {
                        case 'D':
                            timeToCompletePath += processTiming(ref pointer, code[i], keys, pointer.DarkCutscenes, pointer.DarkEndingDestination);
                            break;
                        case 'N':
                            timeToCompletePath += processTiming(ref pointer, code[i], keys, pointer.NormalCutscenes, pointer.NormalEndingDestination);
                            break;
                        case 'H':
                            timeToCompletePath += processTiming(ref pointer, code[i], keys, pointer.HeroCutscenes, pointer.HeroEndingDestination);
                            break;
                    }
                }
                timeToComplete += timeToCompletePath;
                outputString += "Time to Complete Path #" + rp.PathData.ValidPathNumber + " - " + rp.PathData.ValidPathCode + ":" + ((rp.PathData.ValidPathNumber < 100) ? "\t\t" : "\t") + TimeInString(timeToCompletePath) + Environment.NewLine;
            }

            uint timeToCompleteExtraMissions = 0;
            if (ExtraStagesPanel.ExtraStages.Count > 0)
            {
                foreach (var extraStage in ExtraStagesPanel.ExtraStages)
                {
                    var stageName = Common.LevelNames[extraStage.StageDropdown.value];
                    var missionLetter = Common.Levels.Find(l => l.Name == stageName).Missions[extraStage.MissionDropdown.value].ToString()[0];

                    var pointer = AllRoutingLevels.Find(rl => rl.Name == stageName);
                    timeToCompleteExtraMissions += processTiming(pointer, missionLetter, extraStage.Data.keys);
                }

                outputString += "Time to Complete ExtraStages: " + TimeInString(timeToCompleteExtraMissions) + Environment.NewLine;
            }
            timeToComplete += timeToCompleteExtraMissions;

            outputString += "Time to Complete All Paths: " + TimeInString(timeToComplete);

            OutputText.text = (unableToCompleteRoute != null) ? "Unable to complete route due to missing data." + Environment.NewLine + unableToCompleteRoute : outputString;
        }
        else
        {
            OutputText.text = "Unable to complete route due to missing shadow profile data.";
        }
        OutputPanel.SetActive(true);
    }

    private uint processTiming(ref RoutingLevel pointer, char missionCode, bool[]missionKeys, List<int> cutscenes, RoutingLevel endingDestination)
    {
        uint timeToCompletePath = 0;

        //Find the IL to be used for timing.
        var timeEntryToUse = Common.ShadowProfileData.FindTimeEntry(pointer.Name, MisionTypeLookup[missionCode], missionKeys, weaponStatus, NoCCGToggle.isOn);

        if (timeEntryToUse != null)
        {
            timeToCompletePath += timeEntryToUse.Time;

            foreach (var ci in cutscenes)
            {
                timeToCompletePath += (uint)CutsceneData[ci].GetTime();
                CutsceneData[ci].Skippable = true;
            }

            pointer = endingDestination;

            if (timeEntryToUse.Level.Name == "GUN Fortress")
            {
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Dark)
                {
                    weaponStatus.GUNFortressDarkComplete();
                }
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Hero)
                {
                    weaponStatus.GUNFortressHeroComplete();
                }
            }

            if (timeEntryToUse.Level.Name == "Black Comet")
            {
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Dark)
                {
                    weaponStatus.BlackCometDarkComplete();
                }
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Hero)
                {
                    weaponStatus.BlackCometHeroComplete();
                }
            }

            if (timeEntryToUse.Level.Name == "Lava Shelter")
            {
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Dark)
                {
                    weaponStatus.LavaShelterDarkComplete();
                }
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Hero)
                {
                    weaponStatus.LavaShelterHeroComplete();
                }
            }

            if (timeEntryToUse.Level.Name == "Cosmic Fall")
            {
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Dark)
                {
                    weaponStatus.CosmicFallDarkComplete();
                }
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Hero)
                {
                    weaponStatus.CosmicFallHeroComplete();
                }
            }

            if (timeEntryToUse.Level.Name == "Final Haunt")
            {
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Dark)
                {
                    weaponStatus.FinalHauntDarkComplete();
                }
                if (timeEntryToUse.Mission == ProfileLevel.MissionType.Hero)
                {
                    weaponStatus.FinalHauntHeroComplete();
                }
            }
        }
        else
        {
            unableToCompleteRoute += pointer.Name + " " + MisionTypeLookup[missionCode] + Environment.NewLine;
        }

        return timeToCompletePath;
    }

    private uint processTiming(RoutingLevel pointer, char missionCode, bool[] missionKeys)
    {
        uint timeToCompleteMission = 0;

        //Find the IL to be used for timing.
        var timeEntryToUse = Common.ShadowProfileData.FindTimeEntry(pointer.Name, MisionTypeLookup[missionCode], missionKeys, weaponStatus, NoCCGToggle.isOn);

        if (timeEntryToUse != null)
        {
            timeToCompleteMission += timeEntryToUse.Time;
        }
        else
        {
            unableToCompleteRoute += pointer.Name + " " + MisionTypeLookup[missionCode] + Environment.NewLine;
        }

        return timeToCompleteMission;
    }

    private void refreshInterface()
    {
        for(int i = 0; i < RoutingPaths.Count; i++)
        {
            RoutingPaths[i].UpButton.interactable = !(i == 0);
            RoutingPaths[i].DownButton.interactable = !(i == RoutingPaths.Count - 1);

            RoutingPaths[i].index = i + 1;
            RoutingPaths[i].PathLabel.text = "Path #" + RoutingPaths[i].index;

            RoutingPaths[i].PathInputField.text = RoutingPaths[i].DisplayText;

            RoutingPaths[i].DeleteButton.interactable = RoutingPaths.Count > 1;
        }

        AddPathButton.interactable = RoutingPaths.Count < 10;

        CalculateButton.interactable = allPathsValid();
    }

    private bool allPathsValid()
    {
        var pathsValid = true;

        foreach (var rp in RoutingPaths)
        {
            pathsValid &= rp.isValid;
        }

        return pathsValid;
    }

    private void OnRoutingPathUpButtonPressed(RoutingPathObject rpo)
    {
        int currentIndex = RoutingPaths.IndexOf(rpo);
        int nextIndex = (currentIndex - 1 < 0) ? 0 : currentIndex - 1;

        RoutingPaths.Remove(rpo);
        RoutingPaths.Insert(nextIndex, rpo);

        var rpoGameObject = RoutingPathObjectContainer.transform.GetChild(currentIndex);
        rpoGameObject.SetSiblingIndex(nextIndex);

        refreshInterface();
    }

    private void OnRoutingPathDownButtonPressed(RoutingPathObject rpo)
    {
        int currentIndex = RoutingPaths.IndexOf(rpo);
        int nextIndex = (currentIndex + 1 > RoutingPaths.Count) ? RoutingPaths.Count : currentIndex + 1;

        RoutingPaths.Remove(rpo);
        RoutingPaths.Insert(nextIndex, rpo);

        var rpoGameObject = RoutingPathObjectContainer.transform.GetChild(currentIndex);
        rpoGameObject.SetSiblingIndex(nextIndex);

        refreshInterface();
    }

    private void OnRoutingPathDeleteButtonPressed(RoutingPathObject rpo)
    {
        RoutingPaths.Remove(rpo);
        Destroy(rpo.gameObject);
        refreshInterface();
    }

    private void ShowPathSettingsControlPanel(RoutingPathObject routingPath)
    {
        PathSettingsControlPanel.Setup(routingPath);
        PathSettingsControlPanel.gameObject.SetActive(true);
    }

    private void OnRouteSaveFileOpenButtonPressed(RouteSaveFileObject routingSaveFile)
    {
        foreach (var path in RoutingPaths)
        {
            Destroy(path.gameObject);
        }
        RoutingPaths.Clear();

        foreach (var extraStage in ExtraStagesPanel.ExtraStages)
        {
            Destroy(extraStage.gameObject);
        }
        ExtraStagesPanel.ExtraStages.Clear();        

        NewGameToggle.isOn = routingSaveFile.isNewFile;
        NoCCGToggle.isOn = routingSaveFile.isNoCCG;

        foreach (var routingPath in routingSaveFile.RoutingPaths)
        {
            addRoutingPath(routingPath);
        }

        foreach (var extraStage in routingSaveFile.ExtraStages)
        {
            ExtraStagesPanel.AddStage(extraStage);
        }

        lastLoadedSaveFile = routingSaveFile.fileLocation;

        refreshInterface();
        closeSavedRoutesSelection();
    }

    private void OnRouteSaveFileDeleteButtonPressed(RouteSaveFileObject rpo)
    {
        RoutingSaveFiles.Remove(rpo);
        Destroy(rpo.gameObject);
        refreshSavedRouteFiles();
    }

    private void OnRoutingPathInputFieldEditEnd(RoutingPathObject rpo)
    {
        var inputString = rpo.PathInputField.text;
        int inputInt;

        if (int.TryParse(inputString, out inputInt))
        {
            if (inputInt >= 1 && inputInt <= 326)
            {
                //Number is valid
                rpo.PathData.ValidPathNumber = inputInt;
                rpo.PathData.ValidPathCode = PathCodeByNumber[inputInt - 1];
                rpo.PathData.displayType = RoutingPathData.DisplayType.Number;
            }
        }
        else if (inputString.Length == 6)
        {
            var foundPath = PathCodeByNumber.Find(p => p == inputString);
            
            if (foundPath != null)
            {
                //path found and is valid.
                rpo.PathData.ValidPathNumber = PathCodeByNumber.IndexOf(foundPath) + 1;
                rpo.PathData.ValidPathCode = foundPath;
                rpo.PathData.displayType = RoutingPathData.DisplayType.Code;
            }
            else
            {
                //Invalid input
                rpo.PathInputField.text = "";
                rpo.PathData.ValidPathNumber = 0;
                rpo.PathData.ValidPathCode = "";
                rpo.PathData.displayType = RoutingPathData.DisplayType.NotValid;
            }
        }
        else
        {
            //Invalid input
            rpo.PathInputField.text = "";
            rpo.PathData.ValidPathNumber = 0;
            rpo.PathData.ValidPathCode = "";
            rpo.PathData.displayType = RoutingPathData.DisplayType.NotValid;
        }

        refreshInterface();
    }

    public uint[] TimeInSegments(uint milliseconds)
    {
        var hours = (milliseconds / 3600000);
        var minutes = (milliseconds - (hours * 3600000)) / 60000;
        var seconds = (milliseconds - (hours * 3600000) - (minutes * 60000)) / 1000;
        var milli = (milliseconds - (hours * 3600000) - (minutes * 60000) - (seconds * 1000));

        uint[] returnTime = new uint[4] { hours, minutes, seconds, milli };

        return returnTime;
    }

    public string TimeInString(uint milliseconds)
    {
        var timeInSegments = TimeInSegments(milliseconds);
        return timeInSegments[0].ToString("00") + ":" + timeInSegments[1].ToString("00") + ":" + timeInSegments[2].ToString("00") + "." + (timeInSegments[3] / 10).ToString("00");
    }
}
