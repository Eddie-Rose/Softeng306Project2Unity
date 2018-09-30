using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public GameObject dot;
    public float timedEventA = 5.0f;
    EventManager eventManager = new EventManager();
    private CustomEvent _currentEvent;
    public GameObject proposalBox;

    // Use this for initialization
    void Start () {
        proposalBox = GameObject.Find("ProposalBox");
        proposalBox.SetActive(false);


    }

    // Update is called once per frame
    void Update () {
        Timer();
	}

    void doProposalEvent()
    {
        Debug.Log("Hi there");
        _currentEvent = eventManager.getProposalEvent();
        proposalBox.SetActive(true);


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

    public void doEvent(bool execute) {
        Debug.Log("clicked");
        if (execute){

            _currentEvent.consequence();

        }
        else{



        }
        proposalBox.SetActive(false);

    }

}
