using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {
    //Future specialized AI try this video
    //https://www.youtube.com/watch?v=uOobLo2y3KI

    protected override string entityType {get {return "Enemy";}}
    public static List<Enemy> enemyList = new List<Enemy>();

    public float walkSpeed;

    [SerializeField] private float alertRadius;
    [SerializeField] private float attackRadius;


    public bool isInAlertRadius;
    public bool isInAttackRadius;

    private Transform target;
    [SerializeField] private Rigidbody2D enemyRB;
    [SerializeField] private Animator animator;


    //probably redo this at some point
    private Vector2 movement;
    private Vector3 dir;
    private float directionTimer = 0.0f;
    int ranDirection = 0;


    //Attacking
    [SerializeField] private Attack attack;
    private float cooldownTime;
    private float activeTime;
    enum AttackState {
        ready,
        active,
        cooldown
    }
    AttackState state = AttackState.ready;



    protected override void Awake() {
        base.Awake();
        enemyList.Add(this);
    }

    protected override void Update() {
        base.Update();
        //Attack Stuffs
            switch (state) {
            case AttackState.active:
                if (activeTime > 0) {
                    activeTime -= Time.deltaTime;
                } else {
                    state = AttackState.cooldown;
                    cooldownTime = attack.cooldownTime;
                }
            break;
            case AttackState.cooldown:
                if (cooldownTime > 0) {
                    cooldownTime -= Time.deltaTime;
                } else {
                    state = AttackState.ready;
                    canMove = true;
                }
            break;
        }
        
        //Update targeting system for multiple players in future?
        if  (Ally.GetAllyList().Count != 0) {
            foreach (Ally player in Ally.GetAllyList()) {
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
        } else {
            Transform target = transform;
            isInAlertRadius = false;
            isInAttackRadius = false;
            }
    }
    protected override void FixedUpdate() {
        if(!isInAlertRadius) {
            EnemyPatrol();
        }
        if(isInAlertRadius && !isInAttackRadius) {
            EnemyMove(movement);
        }
        if (isInAttackRadius) {
            AttemptAttack();
            enemyRB.velocity = Vector2.zero;    
        }
    }

    //Better pathfinding and velocity-based movement?

    private void EnemyPatrol() {
        if (canMove) {
            if (directionTimer <= 0.0f) {
                ranDirection = Random.Range(0,4);
                directionTimer = 1.0f;
            } else directionTimer -= Time.deltaTime; 
            if (ranDirection == 0) {
                enemyRB.MovePosition((Vector2) transform.position + (new Vector2(0,1) * walkSpeed * Time.deltaTime));
                direction = Enums.Directions.up;
            }
            if (ranDirection == 1) {
                enemyRB.MovePosition((Vector2) transform.position + (new Vector2(0,-1) * walkSpeed * Time.deltaTime));
                direction = Enums.Directions.down;
            }
            if (ranDirection == 2) {
                enemyRB.MovePosition((Vector2) transform.position + (new Vector2(1,0) * walkSpeed * Time.deltaTime));
                direction = Enums.Directions.right;
            }
            if (ranDirection == 3) {
                enemyRB.MovePosition((Vector2) transform.position + (new Vector2(-1,0) * walkSpeed * Time.deltaTime));
                direction = Enums.Directions.left;
            }
        }
    }

    private void EnemyMove(Vector2 movement) {
        if (canMove) {
            enemyRB.MovePosition((Vector2) transform.position + (movement * walkSpeed * Time.deltaTime));
        }
        //Get direction
        if (movement.x > 0 && movement.x >= movement.y) { //Right
            direction = Enums.Directions.right;
        } else if (movement.x < 0 && movement.x <= movement.y) { //Left
            direction = Enums.Directions.left;
        } else if (movement.y > 0 && movement.y >= movement.x) { // Up
            direction = Enums.Directions.up;
        } else if (movement.y < 0 && movement.y <= movement.x) { //Down
            direction = Enums.Directions.down;
        }
    }


    private void AttemptAttack() {
        if (state == AttackState.ready){
            canMove = false;
            attack.Activate(this);
            state = AttackState.active;
            activeTime = attack.activeTime;
        }
    }

    private void OnDestroy() {
        enemyList.Remove(this);
        foreach (Ally player in Ally.GetAllyList()) {
            player.levelUp();
        }
    }
}
