using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Attacks/Player0/Attack_P0A")]
public class Attack_P0A : Attack {

    public GameObject hitbox;

    public override void ActivateUp(Entity parent) {
        GameObject damage = Instantiate(hitbox,parent.transform.position + new Vector3(0,1,0), Quaternion.identity);
        Hitbox box = damage.gameObject.GetComponent<Hitbox>();
        box.damage = 2;
    }
    public override void ActivateRight(Entity parent) {
        GameObject hit0 = Instantiate(hitbox,parent.transform.position + new Vector3(1.4375f,0.4375f,0), Quaternion.identity);
        GameObject hit1 = Instantiate(hitbox,parent.transform.position + new Vector3(1.4375f,-0.4375f,0), Quaternion.identity);
        GameObject hit2 = Instantiate(hitbox,parent.transform.position + new Vector3(1f,0.9375f,0), Quaternion.identity);
        GameObject hit3 = Instantiate(hitbox,parent.transform.position + new Vector3(1f,-0.9375f,0), Quaternion.identity);
        GameObject hit4 = Instantiate(hitbox,parent.transform.position + new Vector3(1.4375f,0.4375f,0), Quaternion.identity);
        GameObject hit5 = Instantiate(hitbox,parent.transform.position + new Vector3(1.4375f,-0.4375f,0), Quaternion.identity);

        
        Hitbox box = hit0.gameObject.GetComponent<Hitbox>();
    }
    public override void ActivateDown(Entity parent) {
        GameObject damage = Instantiate(hitbox,parent.transform.position + new Vector3(0,-1,0), Quaternion.identity);
        Hitbox box = damage.gameObject.GetComponent<Hitbox>();
        box.damage = 2;
    }
    public override void ActivateLeft(Entity parent) {
        GameObject damage = Instantiate(hitbox,parent.transform.position + new Vector3(-1.4375f,0,0), Quaternion.identity);
        Hitbox box = damage.gameObject.GetComponent<Hitbox>();
        box.damage = 2;
    }
}
