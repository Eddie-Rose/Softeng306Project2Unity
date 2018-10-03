using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
    public static int money;
    public int happiness;
    public Text scoreText;
    float showMoney = 5f;
    private StartOptions startScript;

    //Awake is called before Start()
    void Awake()
    {
        //Get a component reference to ShowPanels attached to this object, store in showPanels variable
        //showPanels = GetComponent<ShowPanels>();
        //Get a component reference to StartButton attached to this object, store in startScript variable
        //startScript = GetComponent<StartOptions>();
        
        //showPanels = GameObject.FindObjectOfType(typeof(ShowPanels)) as ShowPanels;
    }

    // Use this for initialization
    void Start () {
        //showPanels = GetComponent<ShowPanels>();
        scoreText = GetComponent<Text>();
        money = 0;
        happiness = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "";
        scoreText.text +=  "CAPITAL:" + money.ToString() + "        ";
        scoreText.text += "TEAM HAPPINESS:" + happiness.ToString() + "\n";
    }

    public void EndGame() {
        //if (showPanels == null)
            //return;
        Time.timeScale = 0;
    }

    public void CancelEndGame()
    {
        //Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        Time.timeScale = 1;
        //call the HidePausePanel function of the ShowPanels script
    }
}
