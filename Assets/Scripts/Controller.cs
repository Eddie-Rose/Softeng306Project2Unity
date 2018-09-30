using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the main game controller.
public class Controller : MonoBehaviour {
    public float timedEventA = 5.0f;
    EventManager eventManager = new EventManager();

    // Tracks he currently active event.
    private CustomEvent _currentEvent;

    public GameObject proposalBox;

    // Track the world controller:
    public GameObject worldControllerObj;

    // Track the tilemap:
    

    void Start () {
        proposalBox = GameObject.Find("ProposalBox");
        proposalBox.SetActive(false);

        // Create the world controller:
        worldControllerObj = new GameObject();
        worldControllerObj.AddComponent(typeof(WorldController));
        //worldControllerObj.GetComponent(typeof(WorldController));

    }

    void Update () {
        Timer();
	}

    void doProposalEvent() {
        _currentEvent = eventManager.getProposalEvent();
        proposalBox.SetActive(true);
    }

    void Timer() {

        timedEventA -= Time.deltaTime;

        if (timedEventA <= 0.0f) {
            Debug.Log("Bye There");
            doProposalEvent();
            timedEventA = 5.0f;
        }

    }

    public void doEvent(bool execute) {
        Debug.Log("clicked");
        if (execute) {
            _currentEvent.consequence();
        }
        else {
            
        }
        proposalBox.SetActive(false);
    }
}
