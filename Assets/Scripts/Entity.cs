using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    //Whether or not the entity can move
    public int maxHealth = 1;

    [HideInInspector] public bool canMove = true;
    
    protected int currentHealth;
    public abstract string entityType { get; }

    //Direction the entity is facing
    public Enums.Directions direction = Enums.Directions.down;

    private void Awake() {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage) {
        Debug.Log("Before: " + currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0) Destroy(this.gameObject);
        Debug.Log("After: " + currentHealth);
    }
}
