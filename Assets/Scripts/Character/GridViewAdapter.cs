using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridViewAdapter : MonoBehaviour
{

    public RectTransform prefab;
    public Text countText;
    public GridLayout gridView;
    public RectTransform content;

    List<CVPrefabView> views = new List<CVPrefabView>();

    // Use this for initialization
    void Start()
    {

    }

    public void OnRecieveNewProposals(List<CVGenerator> models)
    {

        foreach (Transform child in content)
            Destroy(child.gameObject);

        views.Clear();

        int x = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            x++;
            instance.name = "CV " + x;
            CVBoxScript boxScript = (CVBoxScript)instance.GetComponent(typeof(CVBoxScript));

            boxScript.attachedEvent = model;
            instance.transform.SetParent(content, false);
            var view = InitializePrefabView(instance, model);
            views.Add(view);

        }
    }

    CVPrefabView InitializePrefabView(GameObject viewGameObject, CVGenerator model)
    {

        CVPrefabView view = new CVPrefabView(viewGameObject.transform);

        view.summary.text = model._description;
        view.benefits.text = "Potential reward: $" + model._reward + "k";


        return view;
    }

    public void UpdateItems()
    {

    }

    void FetchItemModels(int count, Action onDone)
    {
        //yeild return new WaitForSeconds(2f);
    }

    public class CVPrefabView
    {

        public Text name, ;
        public Button accept, reject;

        public CVPrefabView(Transform rootView)
        {

            summary = rootView.Find("ProposalSummary").GetComponent<Text>();
            benefits = rootView.Find("Benefits").GetComponent<Text>();


        }



    }


}
