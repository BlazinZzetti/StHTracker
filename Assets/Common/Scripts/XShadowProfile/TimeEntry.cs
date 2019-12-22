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
            switch (value)
            {
                case UnlockableWeapons.WeaponState.Level1:
                    unlockableWeapons.GUNFortressDarkComplete();
                    break;
                case UnlockableWeapons.WeaponState.Level2:
                    unlockableWeapons.GUNFortressDarkComplete();
                    unlockableWeapons.GUNFortressHeroComplete();
                    break;
                case UnlockableWeapons.WeaponState.Not_Available:
                    unlockableWeapons.samuraiBladeReset();
                    break;
            }
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
            switch(value)
            {
                case UnlockableWeapons.WeaponState.Level1:
                    unlockableWeapons.BlackCometDarkComplete();
                break;
                case UnlockableWeapons.WeaponState.Level2:
                    unlockableWeapons.BlackCometDarkComplete();
                unlockableWeapons.BlackCometHeroComplete();
                break;
                case UnlockableWeapons.WeaponState.Not_Available:
                    unlockableWeapons.satelliteLaserReset();
                break;
            }
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
            switch(value)
            {
                case UnlockableWeapons.WeaponState.Level1:
                    unlockableWeapons.LavaShelterDarkComplete();
                break;
                case UnlockableWeapons.WeaponState.Level2:
                    unlockableWeapons.LavaShelterDarkComplete();
                unlockableWeapons.LavaShelterHeroComplete();
                break;
                case UnlockableWeapons.WeaponState.Not_Available:
                    unlockableWeapons.eggVacuumReset();
                break;
            }
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
            switch (value)
            {
                case UnlockableWeapons.WeaponState.Level1:
                    unlockableWeapons.CosmicFallDarkComplete();
                    break;
                case UnlockableWeapons.WeaponState.Level2:
                    unlockableWeapons.CosmicFallDarkComplete();
                    unlockableWeapons.CosmicFallHeroComplete();
                    break;
                case UnlockableWeapons.WeaponState.Not_Available:
                    unlockableWeapons.omochaoGunReset();
                    break;
            }
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
            switch (value)
            {
                case UnlockableWeapons.WeaponState.Level1:
                    unlockableWeapons.FinalHauntDarkComplete();
                    break;
                case UnlockableWeapons.WeaponState.Level2:
                    unlockableWeapons.FinalHauntDarkComplete();
                    unlockableWeapons.FinalHauntHeroComplete();
                    break;
                case UnlockableWeapons.WeaponState.Not_Available:
                    unlockableWeapons.healCannonReset();
                    break;
            }
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
