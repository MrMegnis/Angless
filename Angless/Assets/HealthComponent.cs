using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public float maxHP = 100;
    public float curHP = 0; // curHP cann't become higher than maxHP.
    public float damageImmuneTimer = 0; // if <= 0, no damge immune, else show remaining immune time
    public float damageImmune = (float) 0.5; // immune time after taking damage in second;

    void Start() {
        curHP = maxHP;
    }

    void Update() {
        if (damageImmuneTimer > 0)
            damageImmuneTimer -= Time.deltaTime;
    }

    // getHeal and getDamage takes float amount of heal or damage

    public void takeDamage(float damage) {
        if (damage <= 0 || damageImmuneTimer > 0)
            return;
        curHP -= damage;
        damageImmuneTimer = damageImmune;
        if (curHP <= 0)
            kill();
    }

    public void takeHeal(float heal) {
        if (heal <= 0)
            return;
        curHP += heal;
        if (curHP >= maxHP)
            curHP = maxHP;
    }

    // destroy the object, huge changing are coming
    [ContextMenu("Kill")]
    public void kill() {
        Destroy(gameObject);
    }
}
