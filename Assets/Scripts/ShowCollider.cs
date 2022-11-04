using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: From Foxpleyer on https://answers.unity.com/questions/1346279/view-colliders-when-not-selected.html
public class ShowCollider : MonoBehaviour {
    public new bool enabled = true;
    public Vector3 colliderCenter = Vector3.zero;
    public Vector3 colliderSize = Vector3.one;

    void OnDrawGizmos() {
        if(!enabled) return;
        
        Gizmos.color = Color.yellow;
        
        Vector3 size = transform.lossyScale;
         size.x *= colliderSize.x;
         size.y *= colliderSize.y;
         size.z *= colliderSize.z;
         size = transform.rotation * size;

         Gizmos.DrawWireCube(transform.position + transform.rotation * colliderCenter, size);
    }
}