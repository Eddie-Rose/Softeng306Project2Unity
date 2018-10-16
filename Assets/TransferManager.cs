using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void transferToHost(string name, string ethnicity, string gender, string age, string position, int teamwork, int skill)
    {
        string url = "https://kerwinsuniscoolafamirite.000webhostapp.com/submitTransfer.php";
        WWWForm form = new WWWForm();
        form.AddField("namePOST", name);
        form.AddField("genderPOST", gender);
        form.AddField("agePOST", age);
        form.AddField("ethnicityPost", ethnicity);
        form.AddField("positionPOST", position);
        form.AddField("skillPOST", skill);
        form.AddField("teamworkPOST", teamwork);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        Debug.Log("started");
        yield return www;

        
         // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
