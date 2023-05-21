using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MovementComponent))]
public class BulletComponent : WeaponComponent {
    public MovementComponent mc;
    public bool destroyOnCollision = true; // Set true if you want to destroy bullet after collision
    protected float destroyTimer; // Timer for bullet destroy
    public float destroyTime; // Destroy bullet after this time

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
    public override void setWeaponDirection(Vector2 newDirection) {
        base.setWeaponDirection(newDirection);
        mc.setDirection(weaponDirection);
    }
    
}
