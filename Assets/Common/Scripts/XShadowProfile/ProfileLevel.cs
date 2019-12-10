using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileLevel
{
    public enum MissionType
    {
        Dark,
        Normal,
        Hero
    }

    private string name;
    private List<MissionType> missions;
    private bool[] keys = new bool[5];
    private bool usesKeyDoor;
    private bool noCCG;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public List<MissionType> Missions
    {
        get
        {
            return missions;
        }
        set
        {
            missions = value;
        }
    }

    public bool[] Keys
    {
        get
        {
            return keys;
        }
        set
        {
            keys = value;
        }
    }

    public bool UsesKeyDoor
    {
        get
        {
            return usesKeyDoor;
        }
        set
        {
            usesKeyDoor = value;
        }
    }

    public bool NoCCG
    {
        get
        {
            return noCCG;
        }
        set
        {
            noCCG = value;
        }
    }

    public ProfileLevel()
    {

    }

    public ProfileLevel(string name, List<MissionType> missions)
    {
        this.name = name;
        this.missions = missions;
    }

    public ProfileLevel(ProfileLevel level)
    {
        name = level.name;
        missions = level.missions;
        Array.Copy(level.keys, keys, 5);
        usesKeyDoor = level.usesKeyDoor;
        noCCG = level.noCCG;
    }

    public bool Equals(ProfileLevel level)
    {
        return this.name == level.name
            && this.missions == level.missions
            && this.keys[0] == level.keys[0]
            && this.keys[1] == level.keys[1]
            && this.keys[2] == level.keys[2]
            && this.keys[3] == level.keys[3]
            && this.keys[4] == level.keys[4]
            && this.usesKeyDoor == level.usesKeyDoor
            && this.noCCG == level.noCCG;
    }

    public override string ToString()
    {
        return name;
    }
}
