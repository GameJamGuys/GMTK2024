using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    //Class for mouse pointer operations
    public class Pointer
    {
        public static Vector3 GetPointerWorldPosition2D()
        {
            return GetPointerWorldPosition2D(Camera.main);
        }

        public static Vector3 GetPointerWorldPosition2D(Camera camera)
        {
            Vector3 v3 = GetPointerWorldPosition3D(Input.mousePosition, camera);
            v3.z = 0f;
            return v3;
        }

        public static Vector3 GetPointerWorldPosition3D()
        {
            return GetPointerWorldPosition3D(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetPointerWorldPosition3D(Camera camera)
        {
            return GetPointerWorldPosition3D(Input.mousePosition, camera);
        }

        public static Vector3 GetPointerWorldPosition3D(Vector3 screenPos, Camera camera)
        {
            Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
            return worldPos;
        }
    }
}
