using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static float GetAngleFloat(this Vector3 direction)
    {
        direction = direction.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) 
            angle += 360;

        return angle;
    }

    public static Vector3 GetPointOutsideOtherRadiuses(this Vector3 point, List<Vector3> otherVectors, float findRadius, float objectRadius)
    {
        Vector3 offsetPoint = GetRandomOffset(point, findRadius);
        bool isAllRadiusesConsistent = true;
        int count = 0;

        do
        {
            count++;

            isAllRadiusesConsistent = true;

            for (int i = 0; i < otherVectors.Count; i++)
            {
                if (Vector3.Distance(otherVectors[i], offsetPoint) <= objectRadius)
                {
                    isAllRadiusesConsistent = false;
                    offsetPoint = GetRandomOffset(point, findRadius);
                    break;
                }
            }
        } while (!isAllRadiusesConsistent);

        return offsetPoint;
    }

    private static Vector3 GetRandomOffset(Vector3 point, float radius) =>
        point + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)) * radius;

    public static Vector3 RemoveY(this Vector3 v3)
    {
        v3.y = 0f;
        return v3;
    }
}
