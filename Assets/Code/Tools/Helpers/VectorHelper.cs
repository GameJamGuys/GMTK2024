using UnityEngine;

public static class VectorHelper
{
    public static float GetSqrDistance(Vector3 v1, Vector3 v2)
    {
        float xdist = v1.x - v2.x;
        float zdist = v1.z - v2.z;

        return xdist * xdist + zdist * zdist;
    }
}
