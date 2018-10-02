using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVScripts : MonoBehaviour {

    public GameObject CVBoxPrefab;
    public List<CVGenerator> cvs = new List<CVGenerator>();
    public GameObject gridView;

    // Use this for initialization
    void Start () {
        CVBoxPrefab = GameObject.Find("Canvas/Table");
        CVBoxPrefab.SetActive(true);

        doProposalEvent();
    }
	
    void doProposalEvent() {

        cvs.Clear();
        for (int x = 0; x < 3; x++) {
            cvs.Add(new CVGenerator());
        }
        cvs.Add(new CVGenerator());
        GridViewAdapter viewAdapter = (GridViewAdapter)gridView.GetComponent(typeof(GridViewAdapter));
        viewAdapter.OnRecieveNewProposals(cvs);
        CVBoxPrefab.SetActive(true);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
