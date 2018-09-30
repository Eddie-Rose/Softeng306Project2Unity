﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public GameObject dot;
    public float timedEventA = 5.0f;
    EventManager eventManager = new EventManager();

    // Use this for initialization
    void Start () {
        Timer();
        
    }
	
	// Update is called once per frame
	void Update () {
        Timer();
	}

    void doProposalEvent()
    {

        Debug.Log("Hi there");
        ProposalEvent test = eventManager.getProposalEvent();
        test.consequence();

    }

    void Timer() {

        timedEventA -= Time.deltaTime;

        if (timedEventA <= 0.0f)
        {
            Debug.Log("Bye There");
            doProposalEvent();
            timedEventA = 5.0f;
        }

    }
}
