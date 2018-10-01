using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthTriggerScript : MonoBehaviour {
    private SpriteRenderer spR;

	// Use this for initialization
	void Start () {
        spR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer colSPR = other.GetComponent<SpriteRenderer>();
        spR.sortingOrder = colSPR.sortingOrder;
        colSPR.sortingOrder = colSPR.sortingOrder + 1;

        Debug.Log("Collision Event Triggered");
    }

}
