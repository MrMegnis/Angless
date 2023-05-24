using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MovementComponent))]
public class ProjectileComponent : WeaponComponent {
    public MovementComponent mc;
    public bool destroyOnCollision = true; // Set true if you want to destroy projectile after collision
    protected float destroyTimer; // Timer for projectile destroy
    public float destroyTime; // Destroy projectile after this time

    protected override void Start() {
        base.Start();
        mc = GetComponent<MovementComponent>();
        destroyTimer = destroyTime;
    }
    protected void Update() {
        if (destroyTimer > 0) {
            destroyTimer -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collider2D) {
        base.OnTriggerEnter2D(collider2D);
        GameObject target = collider2D.gameObject;
        if(destroyOnCollision && target.tag == targetTag) {
            Destroy(gameObject);
        }
    }
    public override void setDirection(Vector2 newDirection) {
        base.setDirection(newDirection);
        mc.setDirection(weaponDirection);
    }
    
}
