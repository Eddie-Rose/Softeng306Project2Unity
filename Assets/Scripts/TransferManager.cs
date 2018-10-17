using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferManager : MonoBehaviour {


    GameObject TransferPanel;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void transferFromHost()
    {
        TransferPanel = GameObject.Find("TransferPanel");
        int cvCount = TransferPanel.transform.childCount;
        for (int x = 1; x < cvCount; x++) {

            Transform cv = TransferPanel.transform.GetChild(x);
            CVscript cvScript = cv.gameObject.GetComponent<CVscript>();
            cvScript.injectGenerationData("loading...", "loading...", "loading...", "loading...", "loading...", -1, -1);
            cv.position = new Vector3(cv.position.x,cv.position.y,-200);
            
        }

        string url = "https://kerwinsuniscoolafamirite.000webhostapp.com/retrieveTransfer.php";
        WWWForm form = new WWWForm();
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRetrieve(www));
    }

    IEnumerator WaitForRetrieve(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            int cvCount = TransferPanel.transform.childCount;
            int index = 1;

            string[] linesInFile = www.text.Split('\n');
            foreach (string line in linesInFile)
            {
                if (line != "" && index < cvCount)
                {
                    Debug.Log(line);
                    Transform cv = TransferPanel.transform.GetChild(index);
                    CVscript cvScript = cv.gameObject.GetComponent<CVscript>();
                    string[] data = line.Split(':');
                    cvScript.injectGenerationData(data[0],data[3],data[1],data[2], data[4], int.Parse(data[5]), int.Parse(data[6]));
                    cv.position =  new Vector3(cv.position.x,cv.position.y,0);

                    index++;
                }
            }

        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

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
