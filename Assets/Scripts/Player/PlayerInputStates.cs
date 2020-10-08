using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputStates : MonoBehaviour
{
    public static bool fire;
    public static bool newfire;

    public float lastFireTime;

    public static void Fire()
    {
        fire = true;
        newfire = true;
    }

    public static void ResetFire()
    {
        fire = false;
        newfire = false;
    }

    public static bool IsFired()
    {
        return fire;
    }

    public static void NotNewFire()
    {
        newfire = false;
    }


}
