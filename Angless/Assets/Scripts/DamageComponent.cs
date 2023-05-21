using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{

    public float baseDamage = 0;
    public float damageMultiplier = 1;
    public float critRate = 0;
    public float critMultiplier = 2;

    // takes target object, deal baseDamge multiplied by damageMultiplier, critical hit may occurs with critRate probability.

    public void dealDamage(GameObject target) {
        float curDamage = baseDamage * damageMultiplier;
        if (Random.Range((float) 0.0, (float) 1.0) < critRate)
            curDamage *= critMultiplier;
        target.GetComponent<HealthComponent>().takeDamage(curDamage);
    }

    // next functions change something by x (can be negative)

    public void changeDamage(float x) {
        baseDamage +=  x;
    }

    public void changeDamageMultiplier(float x) {
        damageMultiplier += x;
    }

    public void changeCritRate(float x) {
        critRate += x;
    }

    public void changeCritMultiplier(float x) {
        critMultiplier += x;
    }

}
