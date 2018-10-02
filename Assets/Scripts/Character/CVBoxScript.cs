using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVBoxScript : MonoBehaviour
{

    public CVGenerator attachedEvent;
    GameObject cvBoxPrefab;

    public void doEvent(bool accept)
    {

        if (accept)
        {
            Debug.Log("CLIECKED");
            Debug.Log(attachedEvent.name);
            cvBoxPrefab = GameObject.Find("Canvas/Panel/CV_Container");
            cvBoxPrefab.SetActive(false);

        }
        else
        {

            cvBoxPrefab = GameObject.Find("Canvas/Panel/CV_Container");
            cvBoxPrefab.SetActive(false);
            Debug.Log("CLIECKED");



        }

    }

}
