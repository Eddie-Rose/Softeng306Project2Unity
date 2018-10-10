﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the main game controller.
public class Controller : MonoBehaviour {
    public float timedEventA = 5f;
    EventManager eventManager = new EventManager();
    int numEmployees = 1;

    // Tracks he currently active event.
    private CustomEvent _currentEvent;

    public GameObject proposalBoxPrefab;
    public GameObject hireBoxPrefab;

    // Track the world controller:
    public GameObject worldControllerObj;

    public GameObject scrollView;

    // Track the tilemap:

    public List<ProposalEvent> pEvents = new List<ProposalEvent>();


    void Start () {

        createProceduralNPC();
        proposalBoxPrefab = GameObject.Find("EventCanvas/EventPanel");
        proposalBoxPrefab.SetActive(false);
        hireBoxPrefab = GameObject.Find("EventCanvas/HirePanel");
        hireBoxPrefab.SetActive(false);

        // Create the world controller:
        //worldControllerObj = new GameObject();
        //worldControllerObj.AddComponent(typeof(WorldController));
        ////worldControllerObj.GetComponent(typeof(WorldController));

    }

    void Update () {
        Timer();
	}

    void doProposalEvent() {
        pEvents.Clear();
        for (int x = 0; x < numEmployees; x++)
        {
            pEvents.Add(eventManager.getProposalEvent());
        }
        pEvents.Add(eventManager.getProposalEvent());
        ScrollViewAdapter viewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        viewAdapter.OnRecieveNewProposals(pEvents);
        proposalBoxPrefab.SetActive(true);
    }

    void Timer() {

        timedEventA -= Time.deltaTime;

        if (timedEventA <= 0.0f) {
           // Debug.Log("Bye There");
            doProposalEvent();
            timedEventA = 100000f;
        }

        

    }

    public void doEvent(bool execute) {
        Debug.Log("clicked");
        if (execute) {
            _currentEvent.consequence();
        }
        else {
            
        }
        proposalBoxPrefab.SetActive(false);
    }

    public void createProceduralNPC()
    {

        GameObject randomNPC =
            Instantiate(Resources.Load("CharacterGeneration/CustomCharacter"),
            new Vector3(1, 0, 1),
            Quaternion.identity) as GameObject;

        Transform shirtObject = randomNPC.transform.GetChild(0);
        Transform bodyObject = randomNPC.transform.GetChild(1);
        Transform hairObject = randomNPC.transform.GetChild(2);
        Transform pantsObject = randomNPC.transform.GetChild(3);

        string bodyName = "";
        string hairName = "";
        string shirtName = "";
        string pantsName = "";

        switch (Random.Range(1,3))
        {
            case 1:
                bodyName = "body_pale";
                break;
            case 2:
                bodyName = "body_dark";
                break;
        }
        bodyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + bodyName);


        switch (Random.Range(1, 4))
        {
            case 1:
                hairName = "hair_anime_dark";
                break;
            case 2:
                hairName = "hair_bob_ginger";
                break;
            case 3:
                hairName = "hair_ponytail_dark";    
                break;
        }
        hairObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Hairs/" + hairName);


        switch (Random.Range(1, 5))
        {
            case 1:
                shirtName = "shirt_blue";
                break;
            case 2:
                shirtName = "shirt_limegreen";
                break;
            case 3:
                shirtName = "shirt_pink";
                break;
            case 4:
                shirtName = "shirt_white";
                break;
        }
        shirtObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Shirts/" + shirtName);

        switch (Random.Range(1, 3))
        {
            case 1:
                pantsName = "pants_blue";
                break;
            case 2:
                pantsName = "pant_dark";
                break;
        }
        pantsObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Pants/" + pantsName);

        Debug.Log("asdasd");

    }

    // Create a new NPC
    public void createNPC(int seed)
    {

        int x = 1;
        int y = 0;
        numEmployees++;
        Debug.Log("Creating NPC at " + x + " " + y);

        // Basic setup:
        GameObject npc = new GameObject();
        npc.transform.position = new Vector3(x, y, 1);
        npc.AddComponent<SpriteRenderer>();
        npc.AddComponent<WorldObject>();
        npc.AddComponent<Rigidbody2D>();
        npc.AddComponent<EdgeCollider2D>();
        npc.AddComponent<NPCMovement>();

        // Create and add the sprite:
        //@@TODO: randomly generate the NPC.
        Sprite tex = Resources.Load<Sprite>("dude");
        SpriteRenderer spriteRenderer = npc.GetComponent<SpriteRenderer>();

        if (seed == 0)
        {

            tex = Resources.Load<Sprite>("DarkFemale");

        }
        else if(seed == 1) {

            tex = Resources.Load<Sprite>("GingerMale");

        }
        else if (seed == 2)
        {

            tex = Resources.Load<Sprite>("Goku");

        }
        else if (seed == 3)
        {

            tex = Resources.Load<Sprite>("AsianMale");

        }
        //Sprite s = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0, 0));
        spriteRenderer.sprite = tex;
        //spriteRenderer.sortingLayerName = "Players";

        // Set the position of the edge collider to the feet of the sprite.
        EdgeCollider2D collider = npc.GetComponent<EdgeCollider2D>();
        //collider.offset = new Vector2(0, -1.0625f);

        Vector2[] colliderpoints;
        colliderpoints = collider.points;
        colliderpoints[0] = new Vector2(-0.05501652f, 0.09463114f);
        colliderpoints[1] = new Vector2(0.02647161f, 0.1021858f);
        collider.points = colliderpoints;

        Debug.Log(collider.points[0]);

        // Set the rigid body to be kinematic.
        Rigidbody2D rigidbody = npc.GetComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.gravityScale = 0;
        rigidbody.angularDrag = 0;
        rigidbody.mass = 1;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        //Set the size of the sprite to fit the map.
        npc.transform.localScale = new Vector2(1f, 1f);

    }


}
