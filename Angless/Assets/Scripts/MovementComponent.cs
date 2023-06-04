using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Component for moving object.<br/>
/// Continuously moves object in direction
/// </summary>
public class MovementComponent : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    protected Vector2 direction = Vector2.zero;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Move(direction);
    }

    public void Move(Vector2 direction) {
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public void setDirection(Vector2 newDirection) {
        direction = newDirection.normalized;
    }
}
