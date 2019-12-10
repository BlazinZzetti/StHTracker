using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableWeapons
{
    public enum WeaponState
    {
        Not_Available,
        Level2,
        Level1,
    }

    private WeaponState samuraiBlade = WeaponState.Not_Available;
    private WeaponState satelliteLaser = WeaponState.Not_Available;
    private WeaponState eggVacuum = WeaponState.Not_Available;
    private WeaponState omochaoGun = WeaponState.Not_Available;
    private WeaponState healCannon = WeaponState.Not_Available;

    public UnlockableWeapons()
    {

    }

    public WeaponState SamuraiBlade
    {
        get
        {
            return samuraiBlade;
        }
        set
        {
            samuraiBlade = value;
        }
    }
    public WeaponState SatelliteLaser
    {
        get
        {
            return satelliteLaser;
        }
        set
        {
            satelliteLaser = value;
        }
    }
    public WeaponState EggVacuum
    {
        get
        {
            return eggVacuum;
        }
        set
        {
            eggVacuum = value;
        }
    }
    public WeaponState OmochaoGun
    {
        get
        {
            return omochaoGun;
        }
        set
        {
            omochaoGun = value;
        }
    }
    public WeaponState HealCannon
    {
        get
        {
            return healCannon;
        }
        set
        {
            healCannon = value;
        }
    }
}
