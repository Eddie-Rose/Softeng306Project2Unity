using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalBoxScript : MonoBehaviour
{

    public ProposalEvent attachedEvent;
    GameObject proposalBoxPrefab;
    GameObject controller;

    public void doEvent(bool accept)
    {

        if (accept)
        {

            attachedEvent.consequence();

           
        }
        else
        {



        }

        proposalBoxPrefab = GameObject.Find("EventCanvas/EventPanel");
        controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        controllerScript.timedEventA = 5.0f;
        proposalBoxPrefab.SetActive(false);
        Debug.Log("CLIECKED");

    }

}
