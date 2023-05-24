using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {

    public GameObject owner;
    protected DamageComponent ownerDamageComponent;
    public Collider2D attackArea;
    public float weaponMultiplier = 1;
    public string targetTag;
    protected Vector2 weaponDirection;
    virtual protected void Start() {
        ownerDamageComponent = owner.GetComponent<DamageComponent>();
    }

    void Update() {

    }

    /// <summary>
    /// when GameObject with "targetTag" tag enter in weapon Collider2D range this function called and deal damage
    /// </summary>
    virtual protected void OnTriggerEnter2D(Collider2D collider2D) {
        GameObject target = collider2D.gameObject;
        if (target.tag == targetTag) {
            ownerDamageComponent.dealDamage(target);
        }
    }

    virtual public void setDirection(Vector2 newDirection) {
        weaponDirection = newDirection;
    }
    public void setWeaponMultiplier(float newWeaponMultiplier) {
        weaponMultiplier = newWeaponMultiplier;
    }
}
