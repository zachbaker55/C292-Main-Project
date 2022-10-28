using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Continuous, 0 gravity, interpolate, freeze rotation Z
public class PlayerController : Entity {
//animate with https://www.youtube.com/watch?v=whzomFgjT50

    //Components
    [SerializeField] private Rigidbody2D playerRB;
    //Player
    [SerializeField] private float walkSpeed = 6f;
    public static List<PlayerController> playerList = new List<PlayerController>();
    public static List<PlayerController> GetPlayerList() {
        return playerList;
    }

    float inputX;
    float inputY;
    //Direction of player: Down:(0,-1,0), Right(1,0,0), Left(-1,0,0), Up(0,1,0) 

    public override string entityType {get {return "Player";}}

    private void Awake() {
        playerList.Add(this);
    }

    private void Update() {
        //Get movements
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    //Physics go in FixedUpdate()
    private void FixedUpdate() {
        if (canMove) {
            //Movement
            if (inputX != 0 || inputY != 0) { 
                playerRB.velocity = new Vector2(inputX, inputY).normalized * walkSpeed;
                //Direction
                if (inputX > 0 && inputX >= inputY) { //Right
                    direction = Enums.Directions.right;
                } else if (inputX < 0 && inputX <= inputY) { //Left
                    direction = Enums.Directions.left;
                } else if (inputY > 0 && inputY >= inputX) { // Up
                    direction = Enums.Directions.up;
                } else if (inputY < 0 && inputY <= inputX) { //Down
                    direction = Enums.Directions.down;
                }
            } else {
                playerRB.velocity = Vector2.zero;
            }
        } else {
            playerRB.velocity = Vector2.zero;
        }
    }

    private void OnDestroy() {
        playerList.Remove(this);
    }

    
}
