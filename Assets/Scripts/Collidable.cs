using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour {

    [SerializeField] private new BoxCollider2D collider;
    public ContactFilter2D filter;
    private Collider2D[] hits = new Collider2D[10];


    protected virtual void Update() {
        //Collision
        collider.OverlapCollider(filter,hits);
        for (int i = 0; i < hits.Length; i++) {
            if (hits[i] == null) {
                continue;
            }
            OnCollide(hits[i]);
            //Clean array
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collide) {
    }
}
