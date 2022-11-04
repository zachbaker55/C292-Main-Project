using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject {

    //https://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
    //maybe try this to organize animation better
    public Animation animationUp;
    public Animation animationRight;
    public Animation animationDown;
    public Animation animationLeft;
    public new string name;
    public float cooldownTime;
    public float activeTime;
    private bool debugHitbox = true;

    public void Activate(Entity entity) {
        if (entity.direction == Enums.Directions.up) ActivateUp(entity);
        else if (entity.direction == Enums.Directions.right) ActivateRight(entity);
        else if (entity.direction == Enums.Directions.down) ActivateDown(entity);
        else if (entity.direction == Enums.Directions.left) ActivateLeft(entity);
    }
    public virtual void ActivateUp(Entity entity) {} //Position thought + (0,0.5f,0)
    public virtual void ActivateRight(Entity entity) {}
    public virtual void ActivateDown(Entity entity) {} //Position thought + (0,-1.5f,0)
    public virtual void ActivateLeft(Entity entity) {}


    protected Hitbox drawHitbox(Entity parent, float x, float y, Vector3 pos) {
        var obj = new GameObject();
        obj.name = parent.name + " Hitbox " + x + "x" + y;
        obj.transform.position = parent.gameObject.transform.position + pos;
        
        BoxCollider2D collider = obj.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector2(x,y);

        if (debugHitbox) {
            ShowCollider showCollider = obj.AddComponent<ShowCollider>();
            showCollider.colliderSize = new Vector3(x,y,1);
        }
        
        Hitbox hitbox = obj.AddComponent<Hitbox>();
        hitbox.damage = parent.damage;
        hitbox.layerMask = 1 << parent.gameObject.layer;
        hitbox.hitTag = parent.getEntityType();

        return hitbox;
    }

}
