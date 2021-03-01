using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inputs
{
    /* 0 - Forward          * 1 - Backward
     * 2 - Left             * 3 - Right
     * 4 - Pickup           * 5 - boatMoveForward
     * 6 - boatShootLeft   * 7 - boatShootRight
     */

    public static string[] InputArray = new string[]
    {
        "w", "s",
        "a", "d",
        "e", "z",
        "LeftArrow", "RightArrow"
    };
}
