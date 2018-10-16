using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string name;
    public string gender;
    public string age;
    public string ethnicity;
    public string position;
    public int skill;
    public int teamwork;

    public void killNPC()
    {

        
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        Debug.Log(controllerScript.NPCList.Count);
        controllerScript.NPCList.Remove(this.gameObject);
        Debug.Log(controllerScript.NPCList.Count);
        Destroy(this.gameObject);


    }
}
