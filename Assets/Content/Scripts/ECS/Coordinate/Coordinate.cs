using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Coordinate
{
    private static Vector2 ScreenMax;
    private static Vector2 ScreenMin;

    public static Vector2 Max()
    {
        ScreenMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        return ScreenMax;
    }

    public static Vector2 Min()
    {
        ScreenMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        return ScreenMin;
    }
}
