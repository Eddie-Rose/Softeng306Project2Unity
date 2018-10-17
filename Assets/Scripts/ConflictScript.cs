using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ConflictScript : MonoBehaviour {

    /* The digraph showing employee dispositions */
    public InteractionGraph employeeRelationships;

    public ConflictEvent conflictEvent;

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

    void generateConflict()
    {
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        employeeRelationships = controllerScript.getGraph();

        List<InteractionGraph.Relationship> edges = employeeRelationships.getEdges();
        int numEmployees = employeeRelationships.numNodes();

        /* number of conflicts checked = to numEmployees */
        for (int i = 0; i < numEmployees; i++)
        {
            InteractionGraph.Relationship edge = edges[Random.Range(0, edges.Count)];

            /* disposition is in range 0-25 */
            int prob = edge.disposition; // higher disposition means less likely to have a conflict

            

            if (Random.Range(0, 26) > prob)
            {
                int cost = (25 - prob) * Random.Range(50, 101); // cost for option 1
                // Set conflict popup
                transform.Find("Context").GetComponent<Text>().text = edge.source.name + conflictReasons[Random.Range(0, conflictReasons.Length)] + edge.target.name;
                transform.Find("OptionsText").GetComponent<Text>().text = resolutionOptions[Random.Range(0, resolutionOptions.Length)] + "\n\t(Costs: $" + cost + " but " + edge.source.name  + " and " + edge.target.name  + " like each other more";

                // do event..

                edge.incrementDisposition(5);

                break; // only one popup per occurence, more chances to get one with a larger workforce.
            }
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
