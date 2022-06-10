using UnityEngine;

public class Platform
{
    public static Vector2 SetPosition(GameObject platform, float HalfScreen = 2, float Offset = 2f)
    {
        if (PlatfromComponent.Index % 2 == 0)
            HalfScreen = Coordinate.Max().x / HalfScreen;
        else
            HalfScreen = Coordinate.Min().x / HalfScreen;

        float y = platform.transform.position.y + PlatfromComponent.Index * Offset;
        Vector2 v2 = new Vector2(HalfScreen, y);
        PlatfromComponent.Index++;
        return v2;
    }

    public static float Distance(float Current, float Target)
    {
        float distance = Current - Target;
        return distance;
    }
}
