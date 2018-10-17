using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConflictScript : MonoBehaviour {

    public InteractionGraph.Relationship conflictEdge;

    string[] conflictReasons = {" has a differing political opinion to ",
        " feels their culture is being disrespected by ",
        " thinks that they are experiencing rudeness from "

    };

    string[] resolutionOptions =
    {
        "Send them to HR for conflict resolution counseling.",
        "Throw a work party to help them to get to know each other.",
        "Find a suitable compromise for the issue."
    };


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
