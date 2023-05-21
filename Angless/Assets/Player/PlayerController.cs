using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/// <summary>
/// Component for player input
/// </summary>
[RequireComponent(typeof(MovementComponent))]
public class PlayerController : MonoBehaviour {
    // Component response for player input
    Vector2 direction;
    private MovementComponent palyerMovement;
    public GameObject Weapon;

    private void Start() {
        palyerMovement = GetComponent<MovementComponent>();
    }
    private void FixedUpdate() {
        
    }
    /// <summary>
    /// Function for getting messages from Player Control component.<br/>
    ///Save palyer direction input into variable "direction"
    /// </summary>
    /// <param name="value"></param>
    private void OnMove(InputValue value) {
        direction = value.Get<Vector2>();
        direction.Normalize();
        palyerMovement.setDirection(direction);
    }
    /// <summary>
    /// Function for getting messages from Player Control component.<br/>
    /// Spawn weapon in player position and set its direction to mouse.
    /// </summary>
    private void OnFire() {
        Vector2 mouseCord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 curPosition = transform.position;
        Vector2 fireDirection = mouseCord - curPosition;
        fireDirection.Normalize();
        GameObject w = Instantiate(Weapon, this.gameObject.transform.position, Quaternion.identity);
        w.GetComponent<WeaponComponent>().owner = this.gameObject;
        w.GetComponent<WeaponComponent>().setWeaponDirection(fireDirection);
    }
}
