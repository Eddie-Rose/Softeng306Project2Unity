using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour {

    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    List<ProposalPrefabView> views = new List<ProposalPrefabView>();

	// Use this for initialization
	void Start () {
		
	}

    public void OnRecieveNewProposals(List<ProposalEvent> models){

        foreach (Transform child in content)
            Destroy(child.gameObject);

        views.Clear();

        foreach (var model in models){
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializePrefabView(instance, model);
            views.Add(view);

        }
    }

    ProposalPrefabView InitializePrefabView(GameObject viewGameObject, ProposalEvent model) {

        ProposalPrefabView view = new ProposalPrefabView(viewGameObject.transform);

        view.summary.text = model._description;
        view.benefits.text = model._reward.ToString();
        view.detriments.text = model._risk.ToString();

        return view;
    }

    public void UpdateItems(){

    } 
	
	void FetchItemModels (int count, Action onDone) {
		//yeild return new WaitForSeconds(2f);
	}

    public class ProposalPrefabView{

        public Text summary, benefits, detriments;
        public Button accept, reject;

        public ProposalPrefabView(Transform rootView){

            summary = rootView.Find("ProposalSummary").GetComponent<Text>();
            benefits = rootView.Find("Benefits").GetComponent<Text>();
            detriments = rootView.Find("Detriments").GetComponent<Text>();

        }
       


    }

   
}
