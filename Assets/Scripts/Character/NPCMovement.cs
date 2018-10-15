using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls the movement of an NPC.
// This includes a 'loop' of behaviour, where the NPC will wander around the
// environment and interact with various items.
public class NPCMovement : MonoBehaviour {

    [SerializeField]
    Canvas messageCanvas;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer spriteRenderer;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;


    string[] projectArray = new string[] {"How's it going", "This project is difficult", "I need more sick days",
        "Hello", "Hi", "What's Up?", "Let's go","What's the plan?", "When will this project end", "Can't wait for the birthday party"
        };
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        waitTime = 1f;
        walkTime = 1f;
        moveSpeed = 1f;
        messageCanvas.enabled = false;
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.name == "character")
        {
            TurnOnMessage();
        }

    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
        string eventDescription = "";
        eventDescription += projectArray[Random.Range(0, projectArray.Length)] + "\n";
        GameObject NPC = GameObject.Find(this.gameObject.name);
        Debug.Log(NPC.name);
        Transform textTr = NPC.transform.Find("MessageCanvas/Text");
        Text text = textTr.GetComponent<Text>();
        text.text = eventDescription;
        Debug.Log(text);
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "character")
        {
            TurnOffMessage();

        }
    }
    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
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
                    spriteRenderer.flipX = true;
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    spriteRenderer.flipX = false;
                    break;
            }

            moveSpeed = 1f * Random.Range(0.8f, 1.2f);
            walkTime = 1f * Random.Range(0.8f, 1.2f);
            
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
