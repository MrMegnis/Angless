using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    // Component response for camera movement
    public Transform target;
    public Vector3 offset;
    void Update() {
        CameraMove();
    }

    void CameraMove() {
        // Move camera to the target possition with offset;
        Vector3 newPosition = target.position + offset;
        transform.position = newPosition;
    }
}
