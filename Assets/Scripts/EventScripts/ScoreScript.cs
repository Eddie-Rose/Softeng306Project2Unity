using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int money;
    float showMoney = 5f;

	// Use this for initialization
	void Start () {
        money = 0;
	}
	
	// Update is called once per frame
	void Update () {
        showMoney -= Time.deltaTime;

        if (showMoney <= 0.0f)
        {
            Debug.Log(money);
            showMoney = 5.0f;
        }
    }
}
