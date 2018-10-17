using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls the movement of an NPC.
// This includes a 'loop' of behaviour, where the NPC will wander around the
// environment and interact with various items.
public class NPCMovement : MonoBehaviour
{

    [SerializeField]
    Canvas messageCanvas;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer spriteRenderer;
    private CharacterSprites characterSprites;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    private float passiveWalkTime;
    //If >0 passive , if 0 active
    enum walking {passive,active};
    private walking Status = walking.active;
    string[] projectArray = new string[] {
        "How's it going?",
        "This project is difficult",
        "I need more sick days",
        "Hello",
        "Hi",
        "What's up?",
        "Let's go",
        "What's the plan?",
        "When will this project end?",
        "Can't wait for the birthday party"
    };

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterSprites = gameObject.GetComponent<CharacterSprites>();
        waitTime = 1f;
        walkTime = 1f;
        moveSpeed = 1f;
        messageCanvas.enabled = false;
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    private void OnCollisionEnter2D( Collision2D collision)
    {
        int chosenNumber = 0;
        var tag = collision.gameObject.tag;
        if(tag == "Right/Left Walls")
        {
  
            if (Random.value < 0.5f)
                chosenNumber = 0;
            else
                chosenNumber = 2;

            walkDirection = chosenNumber;
        }
        if(tag == "BackWall")
        {
            if (Random.value < 0.5f)
                chosenNumber = 1;
            else
                chosenNumber = 4;

        }
        if (tag == "FrontWall")
        {
            if (Random.value < 0.5f)
                chosenNumber = 1;
            else
                chosenNumber = 4;

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "CEO")
        {
            TurnOnMessage(other);
        }
        else if(other.name.Contains("ChairTriggerFront")) 
        {
            this.gameObject.transform.position = other.transform.position;
            characterSprites.SetDownSprite();
            this.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            this.spriteRenderer.sortingLayerName = "OnChair";
            Status = walking.passive;
            passiveWalkTime = 5f;
        }
        else if (other.name.Contains("ChairTriggerBack"))
        {
            this.gameObject.transform.position = new Vector3(other.transform.position.x,
                    other.gameObject.transform.position.y + 0.070f, other.transform.position.x);
            characterSprites.SetUpSprite();
            this.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            this.spriteRenderer.sortingLayerName = "OnChair";
            Status = walking.passive;
            passiveWalkTime = 5f;
        }
    }

    private void TurnOnMessage(Collider2D other)
    {
        messageCanvas.enabled = true;
        string eventDescription = "";
        eventDescription += projectArray[Random.Range(0, projectArray.Length)] + "\n";
        GameObject NPC = GameObject.Find(this.gameObject.name);
        Transform textTr = NPC.transform.Find("MessageCanvas/Text");
        Text text = textTr.GetComponent<Text>();
        text.text = eventDescription + ", " + other.name;
        Debug.Log(text);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CEO")
        {
            TurnOffMessage();

        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

    public void chooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
   
    void Update ()
    {
        if (isWalking && Status == walking.active)
        {
            walkCounter -= Time.deltaTime;
            if (walkCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

            switch (walkDirection)
            {
                // Up
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    characterSprites.SetUpSprite();
                    break;
                // Right
                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    characterSprites.SetRightSprite();
                    break;
                // Down
                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    characterSprites.SetDownSprite();
                    break;
                // Left
                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    characterSprites.SetLeftSprite();
                    break;
            }

            moveSpeed = 1f * Random.Range(0.5f, 0.8f);
            walkTime = 1f * Random.Range(0.5f, 0.8f);
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0 ) {
                chooseDirection();
            }
        }

        if (Status == walking.passive)
        {
            passiveWalkTime -= Time.deltaTime;
            if(passiveWalkTime < 0)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.5f,
                    this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.x);
                Status = walking.active;
                this.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            }
        }
		
	}
}
