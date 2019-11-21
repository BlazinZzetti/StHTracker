using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class PathRoutingManager : MonoBehaviour
{
    public Button AddPathButton;
    public Button ClearPathsButton;
    public Button ImportPathsButton;
    public Button SavePathsButton;
    public Button CalculateButton;

    public Toggle NewGameToggle;
    public Toggle NoCCGToggle;

    public GameObject RoutingPathObjectContainer;

    public GameObject OutputPanel;
    public Button OutputPanelCloseButton;
    public Text OutputText;

    public List<RoutingPathObject> RoutingPaths = new List<RoutingPathObject>();

    private List<CutsceneData> CutsceneData = new List<CutsceneData>();

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
    #endregion

    public List<string> PathCodeByNumber;

    void Awake()
    {
        initializeCutsceneData();
        initializeRoutingLevels();
        initializePathCodesByNumber();

        NewGameToggle.isOn = false;
        NoCCGToggle.isOn = false;
        OutputText.text = "";

        AddPathButton.onClick.AddListener(addRoutingPath);
        ClearPathsButton.onClick.AddListener(clearRoutingPaths);
        CalculateButton.onClick.AddListener(calculatePaths);

        OutputPanelCloseButton.onClick.AddListener(closeOutputPanel);
    }

    void Start()
    {
        addRoutingPath();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SonicDiablonPD = new RoutingLevel(null, null, null);
        BlackDoomPD = new RoutingLevel(null, null, null);
        SonicDiablonD = new RoutingLevel(null, null, null);

        EggDealerD = new RoutingLevel(null, null, null);
        EggDealerND = new RoutingLevel(null, null, null);
        EggDealerNH = new RoutingLevel(null, null, null);
        EggDealerH = new RoutingLevel(null, null, null);

        BlackDoomH = new RoutingLevel(null, null, null);
        SonicDiablonPH = new RoutingLevel(null, null, null);
        BlackDoomPH = new RoutingLevel(null, null, null);

        GUNFortress = new RoutingLevel(SonicDiablonPD, null, BlackDoomPD);
        BlackComet = new RoutingLevel(SonicDiablonD, null, EggDealerD);
        LavaShelter = new RoutingLevel(EggDealerND, null, EggDealerNH);
        CosmicFall = new RoutingLevel(BlackDoomH, null, EggDealerH);
        FinalHaunt = new RoutingLevel(SonicDiablonPH, null, BlackDoomPH);

        TheARK = new RoutingLevel(GUNFortress, BlackComet, null);
        AirFleet = new RoutingLevel(GUNFortress, BlackComet, LavaShelter);
        IronJungle = new RoutingLevel(BlackComet, LavaShelter, CosmicFall);
        SpaceGadget = new RoutingLevel(LavaShelter, CosmicFall, FinalHaunt);
        LostImpact = new RoutingLevel(null, CosmicFall, FinalHaunt);

        CentralCity = new RoutingLevel(TheARK, null, AirFleet);
        TheDoom = new RoutingLevel(TheARK, AirFleet, IronJungle);
        SkyTroops = new RoutingLevel(AirFleet, IronJungle, SpaceGadget);
        MadMatrix = new RoutingLevel(IronJungle, SpaceGadget, LostImpact);
        DeathRuins = new RoutingLevel(SpaceGadget, null, LostImpact);

        CrypticCastle = new RoutingLevel(CentralCity, TheDoom, SkyTroops);
        PrisonIsland = new RoutingLevel(TheDoom, SkyTroops, MadMatrix);
        CircusPark = new RoutingLevel(SkyTroops, MadMatrix, DeathRuins);

        DigitalCircuit = new RoutingLevel(CrypticCastle, null, PrisonIsland);
        GlyphicCanyon = new RoutingLevel(CrypticCastle, PrisonIsland, CircusPark);
        LethalHighway = new RoutingLevel(PrisonIsland, null, CircusPark);

        Westopolis = new RoutingLevel(DigitalCircuit, GlyphicCanyon, LethalHighway);

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

    private void addRoutingPath()
    {
        var routingPathObject = Instantiate(Resources.Load("RoutingPathObject")) as GameObject;
        RoutingPathObject routingPath = routingPathObject.GetComponent<RoutingPathObject>();
        routingPath.transform.SetParent(RoutingPathObjectContainer.transform, false);

        routingPath.UpButton.onClick.AddListener(() => OnRoutingPathUpButtonPressed(routingPath));
        routingPath.DownButton.onClick.AddListener(() => OnRoutingPathDownButtonPressed(routingPath));
        routingPath.DeleteButton.onClick.AddListener(() => OnRoutingPathDeleteButtonPressed(routingPath));

        routingPath.PathInputField.onEndEdit.AddListener(delegate { OnRoutingPathInputFieldEditEnd(routingPath); });

        RoutingPaths.Add(routingPath);

        refreshInterface();
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

    private void closeOutputPanel()
    {
        OutputPanel.SetActive(false);
    }

    private void calculatePaths()
    {
        foreach (var cs in CutsceneData)
        {
            cs.Skippable = NewGameToggle.isOn;
        }      

        int timeToComplete = 0;
        string outputString = string.Empty;

        foreach (var rp in RoutingPaths)
        {
            var code = rp.ValidPathCode;
            var timeToCompletePath = 0;

            RoutingLevel pointer = Westopolis;
            for (int i = 0; i < 6; i++)
            {
                switch (code[i])
                {
                    case 'D':
                        foreach (var ci in pointer.DarkCutscenes)
                        {
                            timeToCompletePath += CutsceneData[ci].GetTime();
                            CutsceneData[ci].Skippable = true;                            
                        }
                        pointer = pointer.DarkEndingDestination;
                        break;
                    case 'N':
                        foreach (var ci in pointer.NormalCutscenes)
                        {
                            timeToCompletePath += CutsceneData[ci].GetTime();
                            CutsceneData[ci].Skippable = true;                            
                        }
                        pointer = pointer.NormalEndingDestination;
                        break;
                    case 'H':
                        foreach (var ci in pointer.HeroCutscenes)
                        {
                            timeToCompletePath += CutsceneData[ci].GetTime();
                            CutsceneData[ci].Skippable = true;                            
                        }
                        pointer = pointer.HeroEndingDestination;
                        break;
                }
            }
            timeToComplete += timeToCompletePath;
            outputString += "Time to Complete Path #" + rp.ValidPathNumber + " - " + rp.ValidPathCode + ": " + timeToCompletePath + Environment.NewLine;
        }
        outputString += "Time to Complete All Paths: " + timeToComplete;

        OutputText.text = outputString;

        OutputPanel.SetActive(true);
    }

    private void refreshInterface()
    {
        for(int i = 0; i < RoutingPaths.Count; i++)
        {
            RoutingPaths[i].UpButton.interactable = !(i == 0);
            RoutingPaths[i].DownButton.interactable = !(i == RoutingPaths.Count - 1);

            RoutingPaths[i].PathLabel.text = (RoutingPaths.Count > 1) ? "Path #" + (i + 1) : "Path";
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

    private void OnRoutingPathInputFieldEditEnd(RoutingPathObject rpo)
    {
        var inputString = rpo.PathInputField.text;
        int inputInt;

        if (int.TryParse(inputString, out inputInt))
        {
            if (inputInt >= 1 && inputInt <= 326)
            {
                //Number is valid
                rpo.ValidPathNumber = inputInt;
                rpo.ValidPathCode = PathCodeByNumber[inputInt - 1];
            }
        }
        else if (inputString.Length == 6)
        {
            var foundPath = PathCodeByNumber.Find(p => p == inputString);
            
            if (foundPath != null)
            {
                //path found and is valid.
                rpo.ValidPathNumber = PathCodeByNumber.IndexOf(foundPath) + 1;
                rpo.ValidPathCode = foundPath;
            }
            else
            {
                //Invalid input
                rpo.PathInputField.text = "";
                rpo.ValidPathNumber = 0;
                rpo.ValidPathCode = "";
            }
        }
        else
        {
            //Invalid input
            rpo.PathInputField.text = "";
            rpo.ValidPathNumber = 0;
            rpo.ValidPathCode = "";
        }

        refreshInterface();
    }

    //XmlDocument xml;
    ////save code
    //public void LoadConfigFile()
    //{
    //    //Check if config file exists before trying to use it.
    //    if (!File.Exists("config.xml"))
    //    {
    //        //Save will create a file with default parameters from initialization.
    //        Save();
    //    }

    //    //Double Check in case the file creation failed 
    //    //if we attempted to create one.
    //    if (File.Exists("config.xml"))
    //    {
    //        xml.Load("config.xml");
    //        //Get Database Location stored in configXml.
    //        foreach (XmlElement node in xml.DocumentElement)
    //        {
    //            if (node.Name == "DatabaseLocation")
    //            {
    //                databaseLocation = node.InnerText;
    //            }
    //            if (node.Name == "ProfilesData")
    //            {
    //                profileIndex = Int32.Parse(node.GetAttribute("index"));
    //                profileCount = Int32.Parse(node.InnerText);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        MessageBox.Show("Config Xml File Load Failed.");
    //    }
    //}

    //public void Save()
    //{
    //    xml = new XmlDocument();

    //    var baseNode = xml.CreateElement("Config");

    //    var databaseLocationNode = xml.CreateElement("DatabaseLocation");
    //    databaseLocationNode.InnerText = databaseLocation;

    //    var profilesDataNote = xml.CreateElement("ProfilesData");
    //    profilesDataNote.InnerText = profileCount.ToString(); // How many are there?
    //    profilesDataNote.SetAttribute("index", profileIndex.ToString());

    //    baseNode.AppendChild(databaseLocationNode);
    //    baseNode.AppendChild(profilesDataNote);

    //    xml.AppendChild(baseNode);

    //    xml.Save("config.xml");
    //}

    //public void CreateNewProfile()
    //{
    //    using (SaveFileDialog sfd = new SaveFileDialog())
    //    {
    //        sfd.InitialDirectory = Common.Instance.DatabaseLocation;
    //        sfd.AddExtension = true;
    //        sfd.DefaultExt = "xshadowroute";
    //        sfd.Filter = "xshadowroute (*.xshadowroute)|*.xshadowroute";

    //        var result = sfd.ShowDialog();

    //        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
    //        {
    //            if (!File.Exists(sfd.FileName))
    //            {
    //                var name = Path.GetFileNameWithoutExtension(sfd.FileName);
    //                var newProfile = new Profile(name, sfd.FileName);
    //                newProfile.Save();

    //                //Profiles available changed, reset the saved index.
    //                ProfileIndex = 0;

    //                Save();
    //            }
    //        }
    //    }
    //}
}
