using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int money;
    public int happiness;
    public Text scoreText;
    float showMoney = 5f;

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
}
