using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy {
    // enemy shall have dynamic rigidbody with 0 gravity

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == targetTag) {
            dmgComp.dealDamage(other.gameObject);
        }
    }   

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == targetTag) {
            dmgComp.dealDamage(other.gameObject);
        }
    }

    protected override void Move() {
        moveComp.setDirection(agressionTarget.transform.position - transform.position);
    }


}
