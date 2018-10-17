using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * An event which can show conflicts between employees.
 */

public class ConflictEvent : CustomEvent
{
    /* The digraph showing employee dispositions */
    InteractionGraph employeeRelationships;
    


    public ConflictEvent(InteractionGraph digraph) {
        employeeRelationships = digraph;
    }
    public override void consequence() {
        List<InteractionGraph.Relationship> edges = employeeRelationships.getEdges();
        int numEmployees = employeeRelationships.numNodes();

        /* number of conflicts checked = to numEmployees */
        for (int i = 0; i < numEmployees; i++) {
            InteractionGraph.Relationship edge = edges[Random.Range(0, edges.Count)];

            /* disposition is in range 0-25 */
            int prob = edge.disposition; // higher disposition means less likely to have a conflict
            if(Random.Range(0, 26) > prob) {
                // Open some sort of conflict popup

                /*
                 Conflict popup  has some sort of choice, e.g. pay some money and resolve the conflict thus increasing disposition
                 or ignore and disposition stays.
                 */

                // adjust dispositions and money based on player choice

                break; // only one popup per event, more chances to get one with a larger workforce.
            }
        }

    }
}
