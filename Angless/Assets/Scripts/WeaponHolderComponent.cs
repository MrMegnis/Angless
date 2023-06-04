using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>   
/// Class need for weapon control
/// </summary>
public class WeaponHolderComponent : MonoBehaviour {
    public GameObject weaponPrefab;
    void Start() {
        
    }
    void Update() {
        
    }
    /// <summary>   
    /// Spawn a weapon from palyer to mouse direction
    /// </summary>
    public void Attack() {
        Vector2 mouseCord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 curPosition = transform.position;
        Vector2 fireDirection = mouseCord - curPosition;
        fireDirection.Normalize();
        GameObject weapon = Instantiate(weaponPrefab, gameObject.transform.position, Quaternion.identity);
        WeaponComponent weaponComponent = weapon.GetComponent<WeaponComponent>();
        weaponComponent.owner = gameObject;
        weaponComponent.setDirection(fireDirection);
    }
}
