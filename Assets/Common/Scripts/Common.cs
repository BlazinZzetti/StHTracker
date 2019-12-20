using System;
using System.Collections.Generic;
using System.IO;

public static class Common
{
    public static XShadowProfileData ShadowProfileData;

    private static List<ProfileLevel> levels;

    public static List<ProfileLevel> Levels
    {
        get
        {
            return levels;
        }

        set
        {
            levels = value;
        }
    }

    public static string[] LevelNames = new string[]
    {
        "Westopolis",
        "Digital Circuit",
        "Glyphic Canyon",
        "Lethal Highway",
        "Cryptic Castle",
        "Prison Island",
        "Circus Park",
        "Central City",
        "The Doom",
        "Sky Troops",
        "Mad Matrix",
        "Death Ruins",
        "The ARK",
        "Air Fleet",
        "Iron Jungle",
        "Space Gadget",
        "Lost Impact",
        "GUN Fortress",
        "Black Comet",
        "Lava Shelter",
        "Cosmic Fall",
        "Final Haunt",
        "The Last Way"
    };

    public static string SaveFolderPath
    {
        get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StHTracker"; }
    }

    public static string SavedRoutesFolderPath
    {
        get { return SaveFolderPath + "\\SavedRoutes"; }
    }

    public static string TrackerSavesFolderPath
    {
        get { return SaveFolderPath + "\\TrackerSaves"; }
    }

    public static void InitializeSaveFolder()
    {
        if (!Directory.Exists(SaveFolderPath))
        {
            Directory.CreateDirectory(SaveFolderPath);
        }

        if (!Directory.Exists(SavedRoutesFolderPath))
        {
            Directory.CreateDirectory(SavedRoutesFolderPath);
        }

        if (!Directory.Exists(TrackerSavesFolderPath))
        {
            Directory.CreateDirectory(TrackerSavesFolderPath);
        }
    }

    public static void InitalizeLevelData()
    {
        Levels = new List<ProfileLevel>();

        Levels.Add(new ProfileLevel()
        {
            Name = "Westopolis",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Digital Circuit",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Glyphic Canyon",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Lethal Highway",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Cryptic Castle",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Prison Island",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Circus Park",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Central City",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "The Doom",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Sky Troops",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Mad Matrix",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Death Ruins",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "The ARK",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Air Fleet",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Iron Jungle",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Space Gadget",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Lost Impact",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Normal, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "GUN Fortress",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Black Comet",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Lava Shelter",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Cosmic Fall",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "Final Haunt",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Dark, ProfileLevel.MissionType.Hero }
        });

        Levels.Add(new ProfileLevel()
        {
            Name = "The Last Way",
            Missions = new List<ProfileLevel.MissionType>() { ProfileLevel.MissionType.Normal }
        });
    }
}
