using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MovementComponent))]
public class BulletComponent : WeaponComponent {
    public MovementComponent mc;

    protected override void Start() {
        base.Start();
        mc = GetComponent<MovementComponent>();
    }

    public override void setWeaponDirection(Vector2 newDirection) {
        base.setWeaponDirection(newDirection);
        mc.setDirection(weaponDirection);
    }
}
