using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public GameObject dot;
    public float timedEventA = 5.0f;

    // Use this for initialization
    void Start () {
        Timer();
        
    }
	
	// Update is called once per frame
	void Update () {
        Timer();
	}

    void DoDetect()
    {

        Debug.Log("Hi there");
        dot = GameObject.Find("BLUE DOT");
        SimpleController other = (SimpleController)dot.GetComponent(typeof(SimpleController));
        other.ChangeColor();
        
    }

    void Timer() {

        timedEventA -= Time.deltaTime;

        if (timedEventA <= 0.0f)
        {
            Debug.Log("Bye There");
            DoDetect();
            timedEventA = 5.0f;
        }

    }
}
