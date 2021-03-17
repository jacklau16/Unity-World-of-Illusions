using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    public static bool isPlayerLockedAtRoom1 = false;
    public static bool isPlayerLockedAtRoom2 = false;
    public static bool isPlayerLockedAtRoom3 = false;
    public static bool isPlayerLockedAtRoom4 = false;

    public static bool IsPlayerLockedAtAnyRoom()
    {
        return (isPlayerLockedAtRoom1 || isPlayerLockedAtRoom2 || isPlayerLockedAtRoom3 || isPlayerLockedAtRoom4);
    }
}
