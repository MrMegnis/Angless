using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
    // Component response for player input
    Vector2 direction;
    public MovementComponent Movement;
    private void FixedUpdate() {
        Movement.Move(direction);
    }
    private void OnMove(InputValue value) {
        // Function for getting messages from Player Control component
        // Save palyer direction input into variable "direction"
        direction = value.Get<Vector2>();
        direction.Normalize();
        Debug.Log(direction);
    }
}
