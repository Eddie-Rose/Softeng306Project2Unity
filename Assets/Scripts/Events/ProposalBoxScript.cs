using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalBoxScript : MonoBehaviour
{
    //Init gameObjects to be used in the methods
    public ProposalEvent attachedEvent;
    GameObject scrollView;
    GameObject proposalCanvas;
    GameObject controller;
    GameObject currentTaskPrefab;
    private GameObject completeSoundObject;
    private AudioSource completeSound;

    //Event to fire after we accept/decline a proposal
    public void doEvent(bool accept)
    {

        //Set up canvas panels to be false/ true to only show neccessary ones
        scrollView = GameObject.Find("EventCanvas/EventPanel/ScrollView");
        ScrollViewAdapter scrollViewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        proposalCanvas = GameObject.Find("EventCanvas/EventPanel");
        controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));

        //Set audio
        completeSoundObject = GameObject.Find("MenuSounds/CompleteSound");
        completeSound = completeSoundObject.GetComponent<AudioSource>();

        controllerScript.currentTaskPrefab.SetActive(true);
        currentTaskPrefab = GameObject.Find("EventCanvas/CurrentTaskPrefab");
        CurrentTaskController currentTaskController = (CurrentTaskController)currentTaskPrefab.GetComponent(typeof(CurrentTaskController));


        //Event to fire when we accept a proposal
        if (accept)
        {
            //Set the time to live to be a high number to avoid it from deleting 
            attachedEvent._timeToLive = 100000f;

            //Hide canvas without setting it to inactive
            proposalCanvas.transform.localScale = new Vector3(0, 0, 0);

            //Attach proposal to the current prefab task
            currentTaskController.setEvent(attachedEvent);
            float taskTime = attachedEvent._timeToCompleteProposal;
            
            
            //Timer to update slider (progress bar)
            StartCoroutine(Wait(taskTime, currentTaskController, controllerScript, scrollViewAdapter));

        }
        //Fire when we decline a proposal
        else
        {
            //set current task prefab to false and reset timer event
            currentTaskPrefab.SetActive(false);
            controllerScript.addAvailableEmployee(attachedEvent._name);
            scrollViewAdapter.DeleteProposalFromList(this.name);
            controllerScript.proposalTimer = 10.0f;

        }


    }

    //Method to wait until the project has finished and updates progress bar
    IEnumerator Wait(float taskTime, CurrentTaskController currentTaskController, Controller controllerScript, ScrollViewAdapter scrollViewAdapter)
    {
        //Loop until  done
        while (taskTime >= 0.0f)
        {

            //Init the progress bar
            currentTaskController.setSlider((attachedEvent._timeToCompleteProposal) - taskTime, attachedEvent._timeToCompleteProposal);
            
            yield return new WaitForSeconds(0.1f);
            taskTime -= 0.1f;
            


        }

        //Timer finished -> fire consequence and make canvas reappear
        attachedEvent.consequence();
        controllerScript.addAvailableEmployee(attachedEvent._name);
        scrollViewAdapter.DeleteProposalFromList(this.name);
        proposalCanvas.transform.localScale = new Vector3(0.87586f, 0.87586f, 0.87586f);

        //Reset timer
        controllerScript.proposalTimer = 5.0f;

        //Turn off audio
        completeSound.Play();
        currentTaskPrefab.SetActive(false);
        

    }


}
