    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
    // Component response for object movement
    public Rigidbody2D rb;
    public float speed;

    public void Move(Vector2 direction) {
        // Move object in direction * speed
        rb.MovePosition(rb.position + direction * speed);
    }
}
