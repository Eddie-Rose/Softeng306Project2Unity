using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalBoxScript : MonoBehaviour
{

    public ProposalEvent attachedEvent;
    GameObject scrollView;
    GameObject proposalCanvas;
    GameObject controller;
    GameObject currentTaskPrefab;

    public void doEvent(bool accept)
    {
        scrollView = GameObject.Find("EventCanvas/EventPanel/ScrollView");
        ScrollViewAdapter scrollViewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        proposalCanvas = GameObject.Find("EventCanvas/EventPanel");
        controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));

        controllerScript.currentTaskPrefab.SetActive(true);
        currentTaskPrefab = GameObject.Find("EventCanvas/CurrentTaskPrefab");
        CurrentTaskController currentTaskController = (CurrentTaskController)currentTaskPrefab.GetComponent(typeof(CurrentTaskController));



        if (accept)
        {
            attachedEvent._timeToLive = 100000f;


            proposalCanvas.transform.localScale = new Vector3(0, 0, 0);
            currentTaskController.setEvent(attachedEvent);
            float taskTime = attachedEvent._timeToCompleteProposal;
            print(taskTime);
            

            StartCoroutine(Wait(taskTime, currentTaskController, controllerScript, scrollViewAdapter));
            //currentTaskPrefab.SetActive(false);

            






        }
        else
        {
            currentTaskPrefab.SetActive(false);
            controllerScript.addAvailableEmployee(attachedEvent._name);
            scrollViewAdapter.DeleteProposalFromList(this.name);
            controllerScript.timedEventA = 10.0f;



        }

        //proposalCanvas.SetActive(false);
        Debug.Log("CLIECKED");

    }

    
    IEnumerator Wait(float taskTime, CurrentTaskController currentTaskController, Controller controllerScript, ScrollViewAdapter scrollViewAdapter)
    {

        while (taskTime >= 0.0f)
        {

            currentTaskController.setSlider((attachedEvent._timeToCompleteProposal) - taskTime, attachedEvent._timeToCompleteProposal);
            
            yield return new WaitForSeconds(0.1f);
            taskTime -= 0.1f;
            


        }
        attachedEvent.consequence();
        controllerScript.addAvailableEmployee(attachedEvent._name);
        scrollViewAdapter.DeleteProposalFromList(this.name);
        proposalCanvas.transform.localScale = new Vector3(0.87586f, 0.87586f, 0.87586f);

        controllerScript.timedEventA = 5.0f;

        currentTaskPrefab.SetActive(false);
        

    }


}
