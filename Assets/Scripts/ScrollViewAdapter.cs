using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the scrollable proposal event list
public class ScrollViewAdapter : MonoBehaviour
{
    //Init gameobjects
    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    GameObject controller;

    int proposalCounter = 0;

    List<ProposalPrefabView> views = new List<ProposalPrefabView>();
    Controller controllerScript;

    // Use this for initialization
    void Start()
    {
       
        controller = GameObject.Find("ControllerObject");
        controllerScript = (Controller)controller.GetComponent(typeof(Controller));
    }

    //Updates the countdown bar 
    void Update()
    {
        if (views.Count == 0)
            return;
        List<ProposalPrefabView> ProposalsToBeDeleted = new List<ProposalPrefabView>();

        //Loops through each event in the proposal event list
        foreach(ProposalPrefabView prefab in views)
        {

            //updates countdown bar
            prefab.proposalEvent._timeToLive -= Time.deltaTime;
            float progress = Mathf.Clamp01(prefab.proposalEvent._timeToLive / prefab.initialTime);
            prefab.slider.value = progress; 

            //if timetolive less than 0, destroy event
            if (prefab.proposalEvent._timeToLive < 0)
            {
                Destroy(content.Find(prefab.name).gameObject);
                controllerScript.addAvailableEmployee(prefab.proposalEvent._name);
                ProposalsToBeDeleted.Add(prefab);
            }
        }

        //Delete proposals taht have less than 0 time to live
        foreach (ProposalPrefabView prefab in ProposalsToBeDeleted)
            views.Remove(prefab);

        ProposalsToBeDeleted.Clear();

        if (views.Count == 0)
        {
            controllerScript.proposalBoxPrefab.SetActive(false);
            controllerScript.proposalTimer = 5f;
        }
    }

    //public method to delete proposal from list, used when proposal is accepted/ declined
    public void DeleteProposalFromList(string proposalToBeDeleted)
    {
        Destroy(content.Find(proposalToBeDeleted).gameObject);
        foreach(ProposalPrefabView prefab in views)
        {
            if (prefab.name == proposalToBeDeleted)
            {
                views.Remove(prefab);
                break;
            }
        }
        if (views.Count == 0)
        {
            controllerScript.proposalBoxPrefab.SetActive(false);
        }
    }

    //Updates the list when new proposals comes in 
    public void OnRecieveNewProposals(List<ProposalEvent> models)
    {
        //Adds each proposals in the imput list to the the proposal list 
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            proposalCounter++;
            string name = "Proposal Box " + proposalCounter;
            instance.name = name;
            ProposalBoxScript boxScript = (ProposalBoxScript)instance.GetComponent(typeof(ProposalBoxScript));

            boxScript.attachedEvent = model;
            instance.transform.SetParent(content, false);

            //Initialise the view
            var view = InitializePrefabView(instance, model,name);

            //Add to the UI
            views.Add(view);

        }
    }

    //Method to create new prefab with the proposal details
    ProposalPrefabView InitializePrefabView(GameObject viewGameObject, ProposalEvent model, string name)
    {

        ProposalPrefabView view = new ProposalPrefabView(viewGameObject.transform);
        view.proposalEvent = model;
        view.name = name;
        view.initialTime = model._timeToLive;
        view.summary.text = model._description;
        view.slider.value = 1f;
        

        return view;
    }

 
    //New class for the prefab view
    public class ProposalPrefabView
    {
        public ProposalEvent proposalEvent;
        public float initialTime;
        public string name;
        public Text summary; 
        public Slider slider;

        //Constructor to generate and locate the components of the prefab
        public ProposalPrefabView(Transform rootView)
        {
            summary = rootView.Find("ProposalSummary").GetComponent<Text>();
            slider = rootView.Find("Slider").GetComponent<Slider>();
         
        }
    }


}
