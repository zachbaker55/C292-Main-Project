using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Attacks/Enemy/Attack_B1A")]
public class Attack_B1A : Attack {

    public override void ActivateUp(Entity parent) {
        drawHitbox(parent,5,5,new Vector3(0,0,0));
    }
    public override void ActivateRight(Entity parent) {
        drawHitbox(parent,5,5,new Vector3(0,0,0));
    }
    public override void ActivateDown(Entity parent) {
        drawHitbox(parent,5,5,new Vector3(0,0,0));
    }
    public override void ActivateLeft(Entity parent) {
        drawHitbox(parent,5,5,new Vector3(0,0,0));
    }
}
