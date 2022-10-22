using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public float lifespan = 0.5f;
    public int damage = 1;
    //private Vector2 knockback = Vector2.one;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private new string tag = "Player";

    private void Update() {
        lifespan -= Time.deltaTime;
        if (lifespan < 0) Destroy(this.gameObject);
    }

    //If object with trigger collider interacts with a collider that has a hurtbox, calls OnHit() 
    private void OnTriggerEnter2D(Collider2D other) {
        if (layerMask == (layerMask |(1 << other.transform.gameObject.layer))) {
            Hurtbox hurtbox = other.GetComponent<Hurtbox>();
            if (hurtbox != null && other.CompareTag(tag)) {
                OnHit(hurtbox);
                
            }
        }
    }
    protected void OnHit(Hurtbox hurtbox) {
        Debug.Log("I've been hit! " + damage.ToString());
        Destroy(this.gameObject); //remove later and add invincibility frames to hurtbox
    }
}
