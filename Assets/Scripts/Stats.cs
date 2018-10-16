using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public int seed;
    public int happiness;
    public string name;
    public string ethnicity;
    public string gender;
    public string age;
    public string position;
    public int teamwork;
    public int skill;

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

        return comp;
    }

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
