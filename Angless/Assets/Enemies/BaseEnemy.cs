using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseEnemy: MonoBehaviour
{
    public HealthComponent enemyHP;
    public MovementComponent moveComp;
    public DamageComponent dmgComp;
    protected GameObject agressionTarget;
    public string targetTag;


    void setAggression(GameObject target) {
        agressionTarget = target;

    }

    void Start() {
        setAggression(GameObject.FindGameObjectWithTag(targetTag));
    }
    
    //functions that must be overrided in subclasses


    // check if agressionTarget can be attacked right now

    protected abstract void Move() ;

    public void Update() {
        Move();
    }

    void Death() {
        Destroy(gameObject);
        Debug.Log("Death");
    }

}
