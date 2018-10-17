using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script that controlls the current task prefab
public class CurrentTaskController : MonoBehaviour {

    public Text Summary;
    public Text ProposedBy;
    public Text PotentialReward;
    public Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public method to update the prefab with the attached propsal event
    public void setEvent(ProposalEvent attachedEvent)
    {
        string str = attachedEvent._description;
        string mainDescriptionLine = new System.IO.StringReader(str).ReadLine();
        Summary.text = mainDescriptionLine;
        PotentialReward.text = "Potential Reward = $" + attachedEvent._reward + "k";
        ProposedBy.text = "Proposed by:";
        if (attachedEvent._name.Count == 1)
            ProposedBy.text = "Proposed by: " + attachedEvent._name[0];
        else
            ProposedBy.text = "Proposed by: Many Employees";
    }

    //Public method to update the progress bar
    public void setSlider(float timeLeft, float initTime)
    {
        float progressLeft = Mathf.Clamp01(timeLeft / initTime);
        slider.value = progressLeft;
    }
}
