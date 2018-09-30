using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This components needs to be attached to every object in the game.
// It ensures that the game object is rendered correctly.
public class WorldObject : MonoBehaviour {

    SpriteRenderer sr;

    void Start () {
        // Get the sprite renderer of this object.
        if (GetComponent<SpriteRenderer>()) {
            sr = GetComponent<SpriteRenderer>();
            sr.sortingLayerName = "World";
        }
	}
	
	void Update () {
        sr.sortingOrder = (int) Mathf.Floor(-transform.position.y);
	}
}
