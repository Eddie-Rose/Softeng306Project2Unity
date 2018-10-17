using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void setEvent(ProposalEvent attachedEvent)
    {
        string str = attachedEvent._description;
        string mainDescriptionLine = new System.IO.StringReader(str).ReadLine();
        Summary.text = mainDescriptionLine;
        ProposedBy.text = "Proposed by " + attachedEvent._name;
        PotentialReward.text = "Potential reward: " + attachedEvent._reward + "k";
    }

    public void setSlider(float timeLeft, float initTime)
    {
        float progressLeft = Mathf.Clamp01(timeLeft / initTime);
        slider.value = progressLeft;
    }
}
