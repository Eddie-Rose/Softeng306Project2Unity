using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public int money;
    public Text scoreText;
    float showMoney = 5f;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        money = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = money.ToString();
    }
}
