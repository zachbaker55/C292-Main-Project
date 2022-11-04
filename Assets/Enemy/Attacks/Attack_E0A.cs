using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Attacks/Enemy/Attack_E0A")]
public class Attack_E0A : Attack {

    public override void ActivateUp(Entity parent) {
        drawHitbox(parent,1.5f,1,new Vector3(0,1,0));
    }
    public override void ActivateRight(Entity parent) {
        drawHitbox(parent,1,1.5f,new Vector3(1,0,0));
    }
    public override void ActivateDown(Entity parent) {
        drawHitbox(parent,1.5f,1,new Vector3(0,-1,0));
    }
    public override void ActivateLeft(Entity parent) {
        drawHitbox(parent,1,1.5f,new Vector3(-1,0,0));
    }
}
