using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalBoxScript : MonoBehaviour
{

    public ProposalEvent attachedEvent;
    GameObject proposalBoxPrefab;

    public void doEvent(bool accept)
    {

        if (accept)
        {
            Debug.Log("CLIECKED");
            Debug.Log(attachedEvent._name);
            attachedEvent.consequence();
            proposalBoxPrefab = GameObject.Find("Canvas/Panel");
            proposalBoxPrefab.SetActive(false);
           
        }
        else
        {

            proposalBoxPrefab = GameObject.Find("Canvas/Panel");
            proposalBoxPrefab.SetActive(false);
            Debug.Log("CLIECKED");



        }

    }

}
