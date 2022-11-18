using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    //Todo:
    //Invincibility animation? 

    //Whether or not the entity can move

    protected int level = 1;
    public int maxHealth = 1;
    public int damage = 1;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool isInvincible = false;
    
    protected int currentHealth;
    protected abstract string entityType { get; }
    public string getEntityType() {
        return entityType;
    }
    private float damageInvincibility = 0.1f;
    private float invincibilityTimer = 0f;

    //Direction the entity is facing
    public Enums.Directions direction = Enums.Directions.down;

    protected virtual void Awake() {
        currentHealth = maxHealth;
    }

    protected virtual void Update() { 
        //Invincibility, later remove and use Hashsets to detect recent hits PER swing
        if (isInvincible) {
            if (invincibilityTimer <= 0) {
                isInvincible = false;
            } else {
                invincibilityTimer -= Time.deltaTime;
            }
        }
    }

    protected virtual void FixedUpdate() {

    }

    protected virtual void OnDestroy() {

    }

    public virtual void onHit(int damage) {
        invincibilityTimer = damageInvincibility;
        isInvincible = true;
        takeDamage(damage);
        AudioManager.instance.PlaySound("Hit");
    }

    public virtual void takeDamage(int damage) {
        Debug.Log("Before: " + currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0) Destroy(this.gameObject);
        Debug.Log("After: " + currentHealth);
    }

}
