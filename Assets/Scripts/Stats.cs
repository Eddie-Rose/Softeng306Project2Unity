using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public int seed;
    public int happiness;
    public Color haircolor;
    public string name = "tom";
    public string ethnicity = "african";
    public string gender = "male";
    public string age = "29";
    public string position = "entry";
    public int teamwork = 5;
    public int skill = 5;

    public List<InteractionGraph.Relationship> relationships = new List<InteractionGraph.Relationship>();

    //void Update() {}

    void Start()
    {
        
    }



    public int compatiblility(Stats otherNPC) {

        int comp = 0;
        if (ethnicity.Equals(otherNPC.ethnicity)) {

            comp += 5;
            //comp += Random.Range(-2, 8);

        } else {

            //comp += Random.Range(-4, 6);

        }

        if (gender.Equals(otherNPC.gender)) {
            comp += 3;
            //comp += Random.Range(-1, 5);
        } else {
            //comp += Random.Range(-2, 4);
        }

        comp += ((teamwork + otherNPC.teamwork) / 2);

        /* constrain to 0-25 range */
        if (comp > 25)
        {
            comp = 25;
        }
        else if (comp < 0)
        {
            comp = 0;
        }
        return comp;
    }

    public void killNPC()
    {

        
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        Debug.Log(controllerScript.NPCList.Count);
        controllerScript.NPCList.Remove(this.gameObject);
        controllerScript.employeeNames.Remove(this.name);
        Debug.Log(controllerScript.NPCList.Count);
        DestroyImmediate(this.gameObject,true);


    }

    public void TransferNPC() {

        GameObject transfer = GameObject.Find("TransferEvent");
        TransferManager transferScript = transfer.GetComponent<TransferManager>();
        transferScript.transferToHost(name,ethnicity,gender,age,position,teamwork,skill);
        killNPC();
    }
}
