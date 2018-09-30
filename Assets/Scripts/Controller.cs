using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the main game controller.
public class Controller : MonoBehaviour {
    public float timedEventA = 3f;
    EventManager eventManager = new EventManager();

    // Tracks he currently active event.
    private CustomEvent _currentEvent;

    public GameObject proposalBoxPrefab;

    // Track the world controller:
    public GameObject worldControllerObj;

    public GameObject scrollView;

    // Track the tilemap:

    public List<ProposalEvent> pEvents = new List<ProposalEvent>();


    void Start () {
        proposalBoxPrefab = GameObject.Find("Canvas/Panel");
        proposalBoxPrefab.SetActive(false);

        // Create the world controller:
        worldControllerObj = new GameObject();
        worldControllerObj.AddComponent(typeof(WorldController));
        //worldControllerObj.GetComponent(typeof(WorldController));

        

       
    }

    void Update () {
        Timer();
	}

    void doProposalEvent() {
        pEvents.Add(eventManager.getProposalEvent());
        ScrollViewAdapter viewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        viewAdapter.OnRecieveNewProposals(pEvents);
        proposalBoxPrefab.SetActive(true);
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
        proposalBoxPrefab.SetActive(false);
    }


}
