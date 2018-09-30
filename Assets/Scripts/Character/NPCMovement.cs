using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the movement of an NPC.
// This includes a 'loop' of behaviour, where the NPC will wander around the
// environment and interact with various items.
public class NPCMovement : MonoBehaviour {
    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    public void chooseDirection() {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
   
    void Update () {
        if (isWalking) {
            walkCounter -= Time.deltaTime;
            if (walkCounter <= 0) {
                isWalking = false;
                waitCounter = waitTime;
            }

            switch (walkDirection) {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }
        }
        else {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0 ) {
                chooseDirection();
            }
        }
		
	}
}
