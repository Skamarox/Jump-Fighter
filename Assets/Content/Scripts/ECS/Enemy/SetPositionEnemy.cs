using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionEnemy
{
    public Vector2 SetPosition(GameObject Enemy, float HalfScreen = 2, float Offset1 = 2f, float Offset2 = 1f)
    {
        if (PlatfromComponent.Index % 2 == 0)
            HalfScreen = Coordinate.Max().x / HalfScreen;
        else
            HalfScreen = Coordinate.Min().x / HalfScreen;

        float y = Enemy.transform.position.y + (PlatfromComponent.Index - 1) * Offset1;
        Vector2 v2 = new Vector2(HalfScreen, y - Offset2);
        return v2;
    }
}
