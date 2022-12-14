using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Attacks/Player0/Attack_P0A")]
public class Attack_P0A : Attack {

    public override void ActivateUp(Entity parent) {
        drawHitbox(parent,3,2,new Vector3(0,1,0));
    }
    public override void ActivateRight(Entity parent) {
        drawHitbox(parent,2,3,new Vector3(1,0,0));
    }
    public override void ActivateDown(Entity parent) {
        drawHitbox(parent,3,2,new Vector3(0,-1,0));
    }
    public override void ActivateLeft(Entity parent) {
        drawHitbox(parent,2,3,new Vector3(-1,0,0));
    }
}
