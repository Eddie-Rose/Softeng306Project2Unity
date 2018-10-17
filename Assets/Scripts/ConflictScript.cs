using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ConflictScript : MonoBehaviour {

    /* The digraph showing employee dispositions */
    public InteractionGraph employeeRelationships;
    public ConflictEvent conflictEvent;
    public int cost = 0;
    InteractionGraph.Relationship conflictEdge; 



    string[] conflictReasons = 
    {
        " has a differing political opinion to ",
        " feels their culture is being disrespected by ",
        " thinks that they are experiencing rudeness from "

    };

    string[] resolutionOptions =
    {
        "Send them to HR for conflict resolution counseling.",
        "Throw a work party to help them to get to know each other.",
        "Find a suitable compromise for the issue."
    };

    public bool generateConflict()
    {
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        employeeRelationships = controllerScript.getGraph();

        List<InteractionGraph.Relationship> edges = employeeRelationships.getEdges();
        int numEmployees = employeeRelationships.numNodes();

        /* number of conflicts checked = to numEmployees */
        for (int i = 0; i < numEmployees; i++)
        {
            conflictEdge = edges[Random.Range(0, edges.Count)];

            //Debug.Log(conflictEdge.source.name + " -> " + conflictEdge.target.name);

            /* disposition is in range 0-25 */
            int prob = conflictEdge.getDisposition(); // higher disposition means less likely to have a conflict


            //Debug.Log("Prob = " + conflictEdge.source.name + " -> " + conflictEdge.target.name + prob);

            int rand = Random.Range(0, 26);
            //Debug.Log("rand = " + rand);

            if (rand > prob)
            {
                int invProb = 25 - prob;
                int mult = Random.Range(50, 101);
                cost = invProb * mult; // cost for option 1
                //Debug.Log("25 - prob = " + invProb);
                //Debug.Log("Mult = " + mult);
                //Debug.Log("Cost = "+ cost);
                // Set conflict popup
                transform.Find("Context").GetComponent<Text>().text = conflictEdge.source.name + " and " + conflictEdge.target.name + " are having a conflict.\n" 
                    + conflictEdge.source.name + conflictReasons[Random.Range(0, conflictReasons.Length)] + conflictEdge.target.name;
                transform.Find("OptionsText").GetComponent<Text>().text = "Option 1: " + resolutionOptions[Random.Range(0, resolutionOptions.Length)] 
                    + "\n\t(Costs: $" + cost + " but " + conflictEdge.source.name  + " and " + conflictEdge.target.name  + " like each other more so overall happiness increases)";





                return true; // only one popup per occurence, more chances to get one with a larger workforce.
            }
        }
        return false;
    }

    public void processOption(bool option1)
    {
        if (option1)
        {

            GameObject score = GameObject.Find("Score");
            ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));

            ScoreScript.money -= cost;
            cost = 0;

            InteractionGraph.Relationship invEdge = employeeRelationships.getRelationship(conflictEdge.target, conflictEdge.source);

            //Debug.Log("Dispo = " + conflictEdge.source.name + " -> " + conflictEdge.target.name + " = " + conflictEdge.disposition);
            //Debug.Log("Dispo = " + invEdge.source.name + " -> " + invEdge.target.name + " = " + invEdge.disposition);

            conflictEdge.incrementDisposition(5);
            invEdge.incrementDisposition(5);

            //Debug.Log("Dispo = " + conflictEdge.source.name + " -> " + conflictEdge.target.name + " = " + conflictEdge.disposition);
            //Debug.Log("Dispo = " + invEdge.source.name + " -> " + invEdge.target.name + " = " + invEdge.disposition);
                

            this.gameObject.SetActive(false);





        }
        else
        {

            this.gameObject.SetActive(false);

        }
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        controllerScript.conflictEventTimer = 20f;
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
