using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class Container : Collectable {
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite containerEmpty;
    
    protected override void OnCollect() {
        if (!collected) {
            collected = true;
            spriteRenderer.sprite = containerEmpty;
            //Reward from container will go here
        }
    }
    
}
