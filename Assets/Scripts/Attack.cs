using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject {
    public new string name;
    public float cooldownTime;
    public float activeTime;
    
    public void Activate(Entity entity) {
        if (entity.direction == Enums.Directions.up) ActivateUp(entity);
        else if (entity.direction == Enums.Directions.right) ActivateRight(entity);
        else if (entity.direction == Enums.Directions.down) ActivateDown(entity);
        else if (entity.direction == Enums.Directions.left) ActivateLeft(entity);
    }
    public virtual void ActivateUp(Entity entity) {}
    public virtual void ActivateRight(Entity entity) {}
    public virtual void ActivateDown(Entity entity) {}
    public virtual void ActivateLeft(Entity entity) {}

}
