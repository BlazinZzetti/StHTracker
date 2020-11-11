using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

public class XShadowProfileData
{
    private List<TimeEntry> timeEntries;

    public List<TimeEntry> TimeEntries
    {
        get
        {
            return timeEntries;
        }
        set
        {
            timeEntries = value;
        }
    }

    public XShadowProfileData()
    {
        timeEntries = new List<TimeEntry>();
    }

    public XShadowProfileData(string filePathToXProfile)
    {
        timeEntries = new List<TimeEntry>();
        XmlDocument xml = new XmlDocument();

        //Double Check in case the file creation failed 
        //if we attempted to create one.
        if (File.Exists(filePathToXProfile))
        {
            xml.Load(filePathToXProfile);

            //Get Database Location stored in configXml.
            foreach (XmlElement node in xml.DocumentElement)
            {
                if (node.Name == "TimeEntries")
                {
                    foreach (XmlElement i in node.ChildNodes)
                    {
                        if (i.Name == "TimeEntry")
                        {
                            var timeEntry = new TimeEntry();

                            foreach (XmlElement j in i.ChildNodes)
                            {
                                if (j.Name == "Level")
                                {
                                    timeEntry.Level = new ProfileLevel(Common.Levels.First(l => l.Name == j.InnerText));
                                }
                                if (j.Name == "Keys")
                                {
                                    for (int k = 0; k < 5; k++)
                                    {
                                        timeEntry.Keys[k] = bool.Parse(j.ChildNodes[k].InnerText);
                                    }
                                }
                                if (j.Name == "MissionIndex")
                                {
                                    timeEntry.MissionIndex = int.Parse(j.InnerText);
                                }
                                if (j.Name == "UsesKeyDoor")
                                {
                                    timeEntry.UsesKeyDoor = bool.Parse(j.InnerText);
                                }
                                if (j.Name == "NoCCG")
                                {
                                    timeEntry.NoCCG = bool.Parse(j.InnerText);
                                }
                                if (j.Name == "WeaponStates")
                                {
                                    timeEntry.SamuraiBlade = (UnlockableWeapons.WeaponState)int.Parse(j.ChildNodes[0].InnerText);
                                    timeEntry.SatelliteLaser = (UnlockableWeapons.WeaponState)int.Parse(j.ChildNodes[1].InnerText);
                                    timeEntry.EggVacuum = (UnlockableWeapons.WeaponState)int.Parse(j.ChildNodes[2].InnerText);
                                    timeEntry.OmochaoGun = (UnlockableWeapons.WeaponState)int.Parse(j.ChildNodes[3].InnerText);
                                    timeEntry.HealCannon = (UnlockableWeapons.WeaponState)int.Parse(j.ChildNodes[4].InnerText);
                                }
                                if (j.Name == "Time")
                                {
                                    timeEntry.Time = uint.Parse(j.InnerText);
                                }
                                if (j.Name == "VideoLink")
                                {
                                    timeEntry.VideoLink = j.InnerText;
                                }
                            }

                            TimeEntries.Add(timeEntry);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("xProfile File Load Failed.");
        }
    }

    public TimeEntry FindTimeEntry(TimeEntry timeEntry)
    {
        return timeEntries.Find(te => te.Level.Equals(timeEntry.Level)
                                   && te.MissionIndex == timeEntry.MissionIndex
                                   && te.SamuraiBlade == timeEntry.SamuraiBlade
                                   && te.SatelliteLaser == timeEntry.SatelliteLaser
                                   && te.EggVacuum == timeEntry.EggVacuum
                                   && te.OmochaoGun == timeEntry.OmochaoGun
                                   && te.HealCannon == timeEntry.HealCannon);
    }

    public TimeEntry FindTimeEntry(string name, ProfileLevel.MissionType missionType, bool[] keys, UnlockableWeapons weaponStatus, bool NoCCGOnly)
    {
        //Filter out timeEntries for the level.
        var timeEntriesFiltered = timeEntries.FindAll(te => te.Level.Name == name);

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        //Get the appropriate index for the mission type.
        var missionIndex = Common.Levels.Find(l => l.Name == name).Missions.IndexOf(missionType);

        //Filter out timeEntries for the mission.
        timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.MissionIndex == missionIndex);

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        if (NoCCGOnly)
        {
            timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.NoCCG == true);
        }

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        for (int i = 0; i < 5; i++)
        {
            if (keys[i])
            {
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.Level.Keys[i] == keys[i]);

                if (timeEntriesFiltered.Count <= 0)
                {
                    return null;
                }
            }
        }

        switch (weaponStatus.SamuraiBlade)
        {
            case UnlockableWeapons.WeaponState.Not_Available:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.SamuraiBlade == UnlockableWeapons.WeaponState.Not_Available);
                break;
            case UnlockableWeapons.WeaponState.Level1:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.SamuraiBlade == UnlockableWeapons.WeaponState.Not_Available || te.SamuraiBlade == UnlockableWeapons.WeaponState.Level1);
                break;
        }

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        switch (weaponStatus.SatelliteLaser)
        {
            case UnlockableWeapons.WeaponState.Not_Available:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.SatelliteLaser == UnlockableWeapons.WeaponState.Not_Available);
                break;
            case UnlockableWeapons.WeaponState.Level1:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.SatelliteLaser == UnlockableWeapons.WeaponState.Not_Available || te.SamuraiBlade == UnlockableWeapons.WeaponState.Level1);
                break;
        }

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        switch (weaponStatus.EggVacuum)
        {
            case UnlockableWeapons.WeaponState.Not_Available:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.EggVacuum == UnlockableWeapons.WeaponState.Not_Available);
                break;
            case UnlockableWeapons.WeaponState.Level1:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.EggVacuum == UnlockableWeapons.WeaponState.Not_Available || te.SamuraiBlade == UnlockableWeapons.WeaponState.Level1);
                break;
        }

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        switch (weaponStatus.OmochaoGun)
        {
            case UnlockableWeapons.WeaponState.Not_Available:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.OmochaoGun == UnlockableWeapons.WeaponState.Not_Available);
                break;
            case UnlockableWeapons.WeaponState.Level1:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.OmochaoGun == UnlockableWeapons.WeaponState.Not_Available || te.SamuraiBlade == UnlockableWeapons.WeaponState.Level1);
                break;
        }

        if (timeEntriesFiltered.Count <= 0)
        {
            return null;
        }

        switch (weaponStatus.HealCannon)
        {
            case UnlockableWeapons.WeaponState.Not_Available:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.HealCannon == UnlockableWeapons.WeaponState.Not_Available);
                break;
            case UnlockableWeapons.WeaponState.Level1:
                timeEntriesFiltered = timeEntriesFiltered.FindAll(te => te.HealCannon == UnlockableWeapons.WeaponState.Not_Available || te.SamuraiBlade == UnlockableWeapons.WeaponState.Level1);
                break;
        }

        if (timeEntriesFiltered.Count > 0)
        {
            TimeEntry fastestTimeEntry = null;

            foreach (var timeEntry in timeEntriesFiltered)
            {
                if (fastestTimeEntry == null || (fastestTimeEntry != null && fastestTimeEntry.Time > timeEntry.Time))
                {
                    fastestTimeEntry = timeEntry;
                }
            }

            return fastestTimeEntry;
        }

        return null;
    }
}
