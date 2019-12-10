using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEntry
{
    private ProfileLevel level;
    private int missionIndex;
    private uint time = 0;
    private string videoLink = "";

    private UnlockableWeapons unlockableWeapons = new UnlockableWeapons();

    public ProfileLevel Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public int MissionIndex
    {
        get
        {
            return missionIndex;
        }
        set
        {
            missionIndex = value;
        }
    }

    public ProfileLevel.MissionType Mission
    {
        get
        {
            return Level.Missions[missionIndex];
        }
    }

    public bool[] Keys
    {
        get
        {
            return level.Keys;
        }
        set
        {
            level.Keys = value;
        }
    }

    public bool UsesKeyDoor
    {
        get
        {
            return level.UsesKeyDoor;
        }
        set
        {
            level.UsesKeyDoor = value;
        }
    }

    public bool NoCCG
    {
        get
        {
            return level.NoCCG;
        }
        set
        {
            level.NoCCG = value;
        }
    }

    public UnlockableWeapons.WeaponState SamuraiBlade
    {
        get
        {
            return unlockableWeapons.SamuraiBlade;
        }
        set
        {
            unlockableWeapons.SamuraiBlade = value;
        }
    }
    public UnlockableWeapons.WeaponState SatelliteLaser
    {
        get
        {
            return unlockableWeapons.SatelliteLaser;
        }
        set
        {
            unlockableWeapons.SatelliteLaser = value;
        }
    }
    public UnlockableWeapons.WeaponState EggVacuum
    {
        get
        {
            return unlockableWeapons.EggVacuum;
        }
        set
        {
            unlockableWeapons.EggVacuum = value;
        }
    }
    public UnlockableWeapons.WeaponState OmochaoGun
    {
        get
        {
            return unlockableWeapons.OmochaoGun;
        }
        set
        {
            unlockableWeapons.OmochaoGun = value;
        }
    }
    public UnlockableWeapons.WeaponState HealCannon
    {
        get
        {
            return unlockableWeapons.HealCannon;
        }
        set
        {
            unlockableWeapons.HealCannon = value;
        }
    }

    public uint Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }

    public string VideoLink
    {
        get
        {
            return videoLink;
        }
        set
        {
            videoLink = value;
        }
    }
}
