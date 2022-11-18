using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityObject : Entity {
    protected override string entityType {get {return "EntityObject";}}

    protected override void OnDestroy() {
        AudioManager.instance.PlaySound("CrystalBreak");
    }
}
