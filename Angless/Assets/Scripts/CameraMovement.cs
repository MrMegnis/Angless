using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Component for moving camera
/// </summary>
public class CameraMovement : MonoBehaviour {
    // 
    public Transform target;
    public Vector3 offset;
    void Update() {
        CameraMove();
    }

    /// <summary>
    /// Move camera to the target possition with offset
    /// </summary>
    void CameraMove() {
        Vector3 newPosition = target.position + offset;
        transform.position = newPosition;
    }
}
