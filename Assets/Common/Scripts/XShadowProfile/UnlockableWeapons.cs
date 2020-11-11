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

    private bool[] samuraiBlade = new bool[2];
    private bool[] satelliteLaser = new bool[2];
    private bool[] eggVacuum = new bool[2];
    private bool[] omochaoGun = new bool[2];
    private bool[] healCannon = new bool[2];

    public UnlockableWeapons()
    {
        samuraiBlade = new bool[2];
        satelliteLaser = new bool[2];
        eggVacuum = new bool[2];
        omochaoGun = new bool[2];
        healCannon = new bool[2];
    }

    public WeaponState SamuraiBlade
    {
        get
        {
            if (samuraiBlade[0])
            {
                if (samuraiBlade[1])
                {
                    return WeaponState.Level2;
                }
                else
                {
                    return WeaponState.Level1;
                }
            }
            if (samuraiBlade[1])
            {
                return WeaponState.Level1;
            }
            return WeaponState.Not_Available;
        }
    }
    public WeaponState SatelliteLaser
    {
        get
        {
            if (satelliteLaser[0])
            {
                if (satelliteLaser[1])
                {
                    return WeaponState.Level2;
                }
                else
                {
                    return WeaponState.Level1;
                }
            }
            if (satelliteLaser[1])
            {
                return WeaponState.Level1;
            }
            return WeaponState.Not_Available;
        }
    }
    public WeaponState EggVacuum
    {
        get
        {
            if (eggVacuum[0])
            {
                if (eggVacuum[1])
                {
                    return WeaponState.Level2;
                }
                else
                {
                    return WeaponState.Level1;
                }
            }
            if (eggVacuum[1])
            {
                return WeaponState.Level1;
            }
            return WeaponState.Not_Available;
        }
    }
    public WeaponState OmochaoGun
    {
        get
        {
            if (omochaoGun[0])
            {
                if (omochaoGun[1])
                {
                    return WeaponState.Level2;
                }
                else
                {
                    return WeaponState.Level1;
                }
            }
            if (omochaoGun[1])
            {
                return WeaponState.Level1;
            }
            return WeaponState.Not_Available;
        }
    }
    public WeaponState HealCannon
    {
        get
        {
            if (healCannon[0])
            {
                if (healCannon[1])
                {
                    return WeaponState.Level2;
                }
                else
                {
                    return WeaponState.Level1;
                }
            }
            if (healCannon[1])
            {
                return WeaponState.Level1;
            }
            return WeaponState.Not_Available;
        }
    }

    public void samuraiBladeReset()
    {
        samuraiBlade = new bool[2];
    }
    public void satelliteLaserReset()
    {
        satelliteLaser = new bool[2];
    }
    public void eggVacuumReset()
    {
        eggVacuum = new bool[2];
    }
    public void omochaoGunReset()
    {
        omochaoGun = new bool[2];
    }
    public void healCannonReset()
    {
        healCannon = new bool[2];
    }







    public void GUNFortressDarkComplete()
    {
        samuraiBlade[0] = true;
    }

    public void GUNFortressHeroComplete()
    {
        samuraiBlade[1] = true;
    }

    public void BlackCometDarkComplete()
    {
        satelliteLaser[0] = true;
    }

    public void BlackCometHeroComplete()
    {
        satelliteLaser[1] = true;
    }

    public void LavaShelterDarkComplete()
    {
        eggVacuum[0] = true;
    }

    public void LavaShelterHeroComplete()
    {
        eggVacuum[1] = true;
    }

    public void CosmicFallDarkComplete()
    {
        omochaoGun[0] = true;
    }

    public void CosmicFallHeroComplete()
    {
        omochaoGun[1] = true;
    }

    public void FinalHauntDarkComplete()
    {
        healCannon[0] = true;
    }

    public void FinalHauntHeroComplete()
    {
        healCannon[1] = true;
    }
}
