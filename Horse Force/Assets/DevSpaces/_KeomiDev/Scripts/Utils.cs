using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{


    public static Vector3 ScreenToWorld(Camera camera, Vector3 position) {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
    /*
    public static Vector3 ScreenToRay(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.(position);
    }
    */

}

