using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour {

    public RectTransform prefab;
    public Text countText;

	// Use this for initialization
	void Start () {
		
	}

    public void UpdateItems(){

    } 
	
	void FetchItemModels (int count, Action onDone) {
		yeild return new WaitForSeconds(2f);
	}

   
}
