using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {
    //Future specialized AI try this video
    //https://www.youtube.com/watch?v=uOobLo2y3KI

    public override string entityType {get {return "Enemy";}}
    public static List<Enemy> enemyList = new List<Enemy>();

    public float walkSpeed;

    [SerializeField] private float alertRadius;
    [SerializeField] private float attackRadius;


    private bool isInAlertRadius;
    private bool isInAttackRadius;

    private Transform target;
    [SerializeField] private Rigidbody2D enemyRB;
    [SerializeField] private Animator animator;


    //probably redo this at some point
    private Vector2 movement;
    private Vector3 dir;
    private float directionTimer = 0.0f;
    int ranDirection = 0;



    private void Awake() {
        enemyList.Add(this);
    }

    private void Update() {
        animator.SetBool("isAlert", isInAttackRadius);
        //Update targeting system for multiple players in future?
        foreach (PlayerController player in PlayerController.GetPlayerList()) {
            target = player.transform;
        }
        if (Vector3.Distance(transform.position, target.position) <= alertRadius) {
            isInAlertRadius = true;
        } else isInAlertRadius = false;
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRadius) {
            isInAttackRadius = true;
        } else isInAttackRadius = false;
    
        dir = target.position - transform.position;
        movement = dir.normalized;
    }
    private void FixedUpdate() {
        if(!isInAlertRadius) {
            EnemyPatrol();
        }
        if(isInAlertRadius && !isInAttackRadius) {
            EnemyMove(movement);
        }
        if (isInAttackRadius) {
            enemyRB.velocity = Vector2.zero;
        }
    }

    //Better pathfinding and velocity-based movement?

    private void EnemyPatrol() {
        if (directionTimer <= 0.0f) {
            ranDirection = Random.Range(0,4);
            directionTimer = 1.0f;
        } else directionTimer -= Time.deltaTime;
        
        if (ranDirection == 0) {
            enemyRB.MovePosition((Vector2) transform.position + (new Vector2(0,1) * walkSpeed * Time.deltaTime));
        }
            
        if (ranDirection == 1) {
            enemyRB.MovePosition((Vector2) transform.position + (new Vector2(0,-1) * walkSpeed * Time.deltaTime));
        }
        if (ranDirection == 2) {
            enemyRB.MovePosition((Vector2) transform.position + (new Vector2(1,0) * walkSpeed * Time.deltaTime));
        }
        if (ranDirection == 3) {
            enemyRB.MovePosition((Vector2) transform.position + (new Vector2(-1,0) * walkSpeed * Time.deltaTime));
        }
    }

    private void EnemyMove(Vector2 movement) {
        enemyRB.MovePosition((Vector2) transform.position + (movement * walkSpeed * Time.deltaTime));
    }


    private void OnDestroy() {
        enemyList.Remove(this);
    }
}
