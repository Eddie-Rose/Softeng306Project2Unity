using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalBoxScript : MonoBehaviour
{

    public ProposalEvent attachedEvent;
    GameObject scrollView;
    GameObject proposalCanvas;
    GameObject controller;

    public void doEvent(bool accept)
    {
        scrollView = GameObject.Find("EventCanvas/EventPanel/ScrollView");
        ScrollViewAdapter scrollViewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        proposalCanvas = GameObject.Find("EventCanvas/EventPanel");
        controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));

        if (accept)
        {

            attachedEvent.consequence();
            controllerScript.employeeNames.Add(attachedEvent._name);
            scrollViewAdapter.DeleteProposalFromList(this.name);
            controllerScript.timedEventA = 5.0f;






        }
        else
        {

            controllerScript.employeeNames.Add(attachedEvent._name);
            controllerScript.timedEventA = 10.0f;



        }

        //proposalCanvas.SetActive(false);
        Debug.Log("CLIECKED");

    }

}
