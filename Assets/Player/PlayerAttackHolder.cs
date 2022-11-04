using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHolder : MonoBehaviour {
    public Entity entity;
    public Attack attack;
    private float cooldownTime;
    private float activeTime;

    enum AttackState {
        ready,
        active,
        cooldown
    }
    AttackState state = AttackState.ready;
    public string button;

    void Update() {
        switch (state) {
            case AttackState.ready:
                if (Input.GetButtonDown(button)){
                    entity.canMove = false;
                    attack.Activate(entity);
                    state = AttackState.active;
                    activeTime = attack.activeTime;
                }
            break;
            case AttackState.active:
                if (activeTime > 0) {
                    activeTime -= Time.deltaTime;
                } else {
                    state = AttackState.cooldown;
                    cooldownTime = attack.cooldownTime;
                }
            break;
            case AttackState.cooldown:
                if (cooldownTime > 0) {
                    cooldownTime -= Time.deltaTime;
                } else {
                    state = AttackState.ready;
                    entity.canMove = true;
                }
            break;
        }

    }
}
