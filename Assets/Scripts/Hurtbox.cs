using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    //Todo:
    //Invincibility animation
    //Integrate hurtbox into Entity script?

    [SerializeField] private Entity entity;
    public string hurtTag = "";
    [HideInInspector] public bool isInvincible = false;
    private float damageInvincibility = 0.1f;
    private float invincibilityTimer = 0f;

    private void Update() {        
        if (isInvincible) {
            if (invincibilityTimer <= 0) {
                isInvincible = false;
            } else {
                invincibilityTimer -= Time.deltaTime;
            }
        }
    }
    
    public void onHit(int damage) {
        invincibilityTimer = damageInvincibility;
        isInvincible = true;
        entity.takeDamage(damage);
    }

}
