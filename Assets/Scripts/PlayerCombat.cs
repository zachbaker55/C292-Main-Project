using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public Animator animator;

    private void Update() {
        if (Input.GetButtonDown("Attack")) {
            Attack();
        }
    }


    private void Attack() {
        Debug.Log("Attack!");
        //Play attack animation
        //Create hitboxes
        //Use hitboxes
    }

}