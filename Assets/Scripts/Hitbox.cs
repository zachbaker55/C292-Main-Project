using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    //Consider changing from create/delete to Object Pooling

    public float lifespan = 0.5f;
    public int damage = 1;
    //private Vector2 knockback = Vector2.one;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private string hitTag = "";

    private void Update() {
        lifespan -= Time.deltaTime;
        if (lifespan < 0) Destroy(this.gameObject);
    }

    //If object with trigger collider interacts with a collider that has a hurtbox, calls OnHit() 
    private void OnTriggerEnter2D(Collider2D other) {
        if (layerMask == (layerMask |(1 << other.transform.gameObject.layer))) {
            Hurtbox hurtbox = other.GetComponent<Hurtbox>();
            if (hurtbox != null) {
                if (hitTag == "Player" || hitTag == "Ally") {
                    if (hurtbox.hurtTag != "Player" && hurtbox.hurtTag != "Ally" && hurtbox.isInvincible == false) {
                        hurtbox.onHit(damage);
                    }
                } else if (hurtbox.hurtTag != hitTag && hurtbox.isInvincible == false) {
                    hurtbox.onHit(damage);
                }
            }
        }
    }
}
