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

        view.name.text = model.name;
        view.age.text = "Age: " + model.age;
        view.dob.text = "D.O.B.: " + model.dob;
        view.summary.text = model.summary;
        view.skill.text = "" + model.skill;
        view.teamwork.text = "" + model.teamwork;
        view.gender.text = "" + model.gender;
        view.nationality.text = "" + model.nationality;


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

        public Text name, gender, age, nationality, dob, summary, skill, teamwork;
        public Button accept, reject;

        public CVPrefabView(Transform rootView)
        {

            name = rootView.Find("Name").GetComponent<Text>();
            gender = rootView.Find("Gender").GetComponent<Text>();
            age = rootView.Find("Age").GetComponent<Text>();
            nationality = rootView.Find("Nationality").GetComponent<Text>();
            dob = rootView.Find("DOB").GetComponent<Text>();
            summary = rootView.Find("Summary").GetComponent<Text>();
            skill = rootView.Find("Skill").GetComponent<Text>();
            teamwork = rootView.Find("Teamwork").GetComponent<Text>();

        }



    }


}
