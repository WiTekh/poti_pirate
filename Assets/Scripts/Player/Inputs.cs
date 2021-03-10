using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inputs
{
    /* 0 - Forward          * 1 - Backward
     * 2 - Left             * 3 - Right
     * 4 - Pickup           * 5 - boatMoveForward
     * 6 - boatShootLeft   * 7 - boatShootRight
     * 8 - Repair
     */

    public static int camSensivity;
    public static KeyCode[] InputArray = new KeyCode[]
    {
        KeyCode.W, KeyCode.S,
        KeyCode.A, KeyCode.D,
        KeyCode.E, KeyCode.Z,
        KeyCode.Q, KeyCode.E,
        KeyCode.R
    };
}
