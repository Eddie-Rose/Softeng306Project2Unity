using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour
{

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

    void Update()
    {
        if (views.Count == 0)
            return;
        List<ProposalPrefabView> ProposalsToBeDeleted = new List<ProposalPrefabView>();
        foreach(ProposalPrefabView prefab in views)
        {
            prefab.proposalEvent._timeToLive -= Time.deltaTime;
            float progress = Mathf.Clamp01(prefab.proposalEvent._timeToLive / prefab.initialTime);
            prefab.slider.value = progress; 

            if (prefab.proposalEvent._timeToLive < 0)
            {
                Destroy(content.Find(prefab.name).gameObject);
                controllerScript.addAvailableEmployee(prefab.proposalEvent._name);
                ProposalsToBeDeleted.Add(prefab);
            }
        }
        foreach (ProposalPrefabView prefab in ProposalsToBeDeleted)
            views.Remove(prefab);

        ProposalsToBeDeleted.Clear();

        if (views.Count == 0)
        {
            controllerScript.proposalBoxPrefab.SetActive(false);
            controllerScript.timedEventA = 5f;
        }
    }

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

    public void OnRecieveNewProposals(List<ProposalEvent> models)
    {

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            proposalCounter++;
            string name = "Proposal Box " + proposalCounter;
            instance.name = name;
            ProposalBoxScript boxScript = (ProposalBoxScript)instance.GetComponent(typeof(ProposalBoxScript));

            boxScript.attachedEvent = model;
            instance.transform.SetParent(content, false);
            var view = InitializePrefabView(instance, model,name);
            views.Add(view);

        }
    }

    ProposalPrefabView InitializePrefabView(GameObject viewGameObject, ProposalEvent model, string name)
    {

        ProposalPrefabView view = new ProposalPrefabView(viewGameObject.transform);
        view.proposalEvent = model;
        view.name = name;
        view.initialTime = model._timeToLive;
        view.summary.text = model._description;
        //view.benefits.text = "Potential reward: $" + model._reward + "k";
        view.slider.value = 1f;
        

        return view;
    }

    

    void FetchItemModels(int count, Action onDone)
    {
        //yeild return new WaitForSeconds(2f);
    }

    public class ProposalPrefabView
    {
        public ProposalEvent proposalEvent;
        public float initialTime;
        public string name;
        public Text summary; //, benefits;
       // public Button accept, reject;
        public Slider slider;

        public ProposalPrefabView(Transform rootView)
        {
            summary = rootView.Find("ProposalSummary").GetComponent<Text>();
            //benefits = rootView.Find("Benefits").GetComponent<Text>();
            slider = rootView.Find("Slider").GetComponent<Slider>();
         
        }
    }


}
