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
    int proposalCounter = 0;

    List<ProposalPrefabView> views = new List<ProposalPrefabView>();

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        
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
    }

    public void OnRecieveNewProposals(List<ProposalEvent> models)
    {

        //foreach (Transform child in content)
        //    Destroy(child.gameObject);

        //views.Clear();

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
        view.name = name;
        view.summary.text = model._description;
        view.benefits.text = "Potential reward: $" + model._reward + "k";
        

        return view;
    }

    

    void FetchItemModels(int count, Action onDone)
    {
        //yeild return new WaitForSeconds(2f);
    }

    public class ProposalPrefabView
    {

        public Text summary, benefits;
        public Button accept, reject;
        public string name;

        public ProposalPrefabView(Transform rootView)
        {
            summary = rootView.Find("ProposalSummary").GetComponent<Text>();
            benefits = rootView.Find("Benefits").GetComponent<Text>();
         
        }
    }


}
