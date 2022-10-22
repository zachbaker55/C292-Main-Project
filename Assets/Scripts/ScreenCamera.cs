using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCamera : MonoBehaviour {

    //Starting position, then current position
    private Vector3 currentPos = new Vector3(0,0,-10);
    //Object of focus; the player
    public Transform focus;
    //Screensize = resolution/pixels per unit (16)
    public float screenSizeX = 25.0f;
    public float screenSizeY = 14.0f;

    //LateUpdate() gets called after all Update()s
    private void LateUpdate() {
        //Checks to see if focus is within bounds, otherwise corrects itself
        if (focus != null) {
            if (focus.position.x > currentPos.x + (screenSizeX/2.0))
                currentPos.x += screenSizeX;
            if (focus.position.x < currentPos.x - (screenSizeX/2.0))
                currentPos.x -= screenSizeX;
            if (focus.position.y > currentPos.y + (screenSizeY/2.0))
                currentPos.y += screenSizeY;
            if (focus.position.y < currentPos.y - (screenSizeY/2.0))
                currentPos.y -= screenSizeY;
        }

        //updates transform.positon
        transform.position = currentPos;
    }
}
    //Not what I need right now, but maybe use this code later...
    // public Transform focus;
    // public float boundX = 12.5f;
    // public float boundY = 7.5f;
    // private void LateUpdate(){
    //     Vector3 delta = Vector3.zero;
    //     //Within X bounds
    //     float deltaX = focus.position.x - transform.position.x;
    //     if(deltaX > boundX || deltaX < -boundX) {
    //         if(transform.position.x < focus.position.x) {
    //             delta.x = deltaX - boundX;
    //         } else {
    //             delta.x = deltaX + boundX;
    //         }
    //     }
    //     //Within Y bounds
    //     float deltaY = focus.position.y - transform.position.y;
    //     if(deltaY > boundY || deltaY < -boundY) {
    //         if(transform.position.y < focus.position.y) {
    //             delta.y = deltaY - boundY;
    //         } else {
    //             delta.y = deltaY + boundY;
    //         }
    //     }

    //     //Move camera
    //     transform.position += new Vector3(delta.x, delta.y, 0);
    // }
