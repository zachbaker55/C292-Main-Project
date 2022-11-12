using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Entity {
    protected override string entityType {get {return "Ally";}}

    [SerializeField] protected float walkSpeed = 6f;
    public static List<Ally> allyList = new List<Ally>();
    public static List<Ally> GetAllyList() {
        return allyList;
    }

    protected override void Awake() {
        base.Awake();
        allyList.Add(this);
    }

    public virtual void levelUp(){
        level += 1;
        maxHealth += 1;
        currentHealth = maxHealth;
        damage += 1;
        Debug.Log($"Level up! Level is {level}, Damage is {damage}, Health is {maxHealth}");
    }



    protected override void OnDestroy() {
        base.OnDestroy();
        allyList.Remove(this);
    }

}
