using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Continuous, 0 gravity, interpolate, freeze rotation Z
public class PlayerController : MonoBehaviour {
//animate with https://www.youtube.com/watch?v=whzomFgjT50

    //Components
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] private GameObject AllyAttack16x16;

    //Player
    [SerializeField] private float walkSpeed = 6f;
    float inputX;
    float inputY;
    //Direction of player: Down:(0,-1,0), Right(1,0,0), Left(-1,0,0), Up(0,1,0)
    Vector3 direction = new Vector3(0,-1,0); //Direction of player: 

    private void Update() {
        if (Input.GetButtonDown("Attack")) {
            Attack();
        }
        //Get movements
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    //Physics go in FixedUpdate()
    private void FixedUpdate() {
        //Movement
        if (inputX != 0 || inputY != 0) { 
            rigidbody.velocity = new Vector2(inputX, inputY).normalized * walkSpeed;
            //Direction
            if (inputX > 0 && inputX >= inputY) { //Right
                direction = new Vector3(1,0,0);
            } else if (inputX < 0 && inputX <= inputY) { //Left
                direction = new Vector3(-1,0,0);
            } else if (inputY > 0 && inputY >= inputX) { // Up
                direction = new Vector3(0,1,0);
            } else if (inputY < 0 && inputY <= inputX) { //Down
                direction = new Vector3(0,-1,0);
            }
        } else {
            rigidbody.velocity = Vector2.zero;
        }
    }

    private void Attack() {
        //Create an attack manager to improve
        GameObject hitbox = Instantiate(AllyAttack16x16,transform.position + direction, Quaternion.identity);
        Hitbox box = hitbox.gameObject.GetComponent<Hitbox>();
        box.damage = 2;
    }

    
}
