﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the movement of the player.
public class PlayerMovement : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = int.MaxValue - (int) Mathf.Floor(transform.position.y);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = rb2d.position + new Vector2(moveHorizontal *0.01f, moveVertical*0.01f);

        rb2d.MovePosition(movement);
    }
}

