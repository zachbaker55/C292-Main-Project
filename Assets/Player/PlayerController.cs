using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Ally {
//animate with https://www.youtube.com/watch?v=whzomFgjT50
    protected override string entityType {get {return "Player";}}

    //Components
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private StatDisplay statDisplay;

    //Player

    float inputX;
    float inputY;

    protected override void Awake() {
        base.Awake();
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
        statDisplay.setDamage(damage);
    }

    protected override void Update() {
        base.Update();
        //Get movements
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    //Physics go in FixedUpdate()
    protected override void FixedUpdate() {
        base.FixedUpdate();
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

    public override void levelUp() {
        base.levelUp();
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
        statDisplay.setDamage(damage);
    }

    public override void onHit(int damage) {
        base.onHit(damage);
        healthBar.setHealth(currentHealth);
    }

    public override void takeDamage(int damage) {
        Debug.Log("Before: " + currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0) SceneManager.LoadScene(3);
        Debug.Log("After: " + currentHealth);
    }
}
