using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    //Consider changing from create/delete to Object Pooling

    public float lifespan = 0.5f;
    public int damage;
    public LayerMask layerMask;
    public string hitTag = "";

    private void Update() {
        lifespan -= Time.deltaTime;
        if (lifespan < 0) Destroy(this.gameObject);
    }

    //If object with trigger collider interacts with a collider that has a hurtbox, calls OnHit() 
    private void OnTriggerEnter2D(Collider2D other) {
        if (layerMask == (layerMask |(1 << other.transform.gameObject.layer))) {
            Entity entity = other.GetComponent<Entity>();
            if (entity != null) {
                if (hitTag == "Player" || hitTag == "Ally") {
                    if (entity.getEntityType() != "Player" && entity.getEntityType() != "Ally" && entity.isInvincible == false) {
                        entity.onHit(damage);
                    }
                } else if (entity.getEntityType() != hitTag && entity.isInvincible == false) {
                    entity.onHit(damage);
                }
            }
        }
    }
}
