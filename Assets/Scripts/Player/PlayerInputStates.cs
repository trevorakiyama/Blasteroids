using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputStates : MonoBehaviour
{
    public static bool fire;

    public float lastFireTime;

    public static void Fire()
    {
        fire = true;
    }

    public static void ResetFire()
    {
        fire = false;
    }

    public static bool IsFired()
    {
        return fire;
    }


}
