using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceComponent : MonoBehaviour {
    public int experienceAmount;
    private void OnTriggerEnter2D(Collider2D collider2D) {
        GameObject target = collider2D.gameObject;
        if (target.tag == "Player") {
            LevelSystemComponent levelSystem = target.GetComponent<LevelSystemComponent>();
            levelSystem.GainXP(experienceAmount);
            Destroy(gameObject);
        }
    }
}
