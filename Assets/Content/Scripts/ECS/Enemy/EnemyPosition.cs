using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition
{
    public static float Distance(float Current, float Target)
    {
        float distance = Current - Target;
        return distance;
    }
}
