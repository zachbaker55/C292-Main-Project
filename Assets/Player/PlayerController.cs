using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Ally {
//animate with https://www.youtube.com/watch?v=whzomFgjT50
    protected override string entityType {get {return "Player";}}

    //Components
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Animator animator;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private StatDisplay statDisplay;

    //Player

    private Vector2 movement;

    protected override void Awake() {
        base.Awake();
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
        statDisplay.setDamage(damage);
    }

    protected override void Update() {
        base.Update();
        //Get movements
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //Direction
        if (movement.x > 0 && movement.x >= movement.y) { //Right
            direction = Enums.Directions.right;
        } else if (movement.x < 0 && movement.x <= movement.y) { //Left
            direction = Enums.Directions.left;
        } else if (movement.y > 0 && movement.y >= movement.x) { // Up
            direction = Enums.Directions.up;
        } else if (movement.y < 0 && movement.y <= movement.x) { //Down
            direction = Enums.Directions.down;
        }
        //Later connect animator float and direction enum?
        if (movement.x != 0 || movement.y != 0) {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    //Physics go in FixedUpdate()
    protected override void FixedUpdate() {
        base.FixedUpdate();
        if (canMove) {
            //Movement
            if (movement.x != 0 || movement.y != 0) { 
                playerRB.velocity = new Vector2(movement.x, movement.y).normalized * walkSpeed;
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
