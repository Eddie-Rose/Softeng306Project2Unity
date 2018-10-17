using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Dictionary<string, int> seed = new Dictionary<string, int>();
    public int happiness;

    // Sprite data
    public Color hairColor;
    public Color pantsColor;
    public Color shirtColor;
    public string bodyName = "";
    public string hairName = "";

    // Display data
    public string name = "Tom";
    public string ethnicity = "African";
    public string gender = "Male";
    public string age = "29";
    public string position = "Entry";
    public int teamwork = 5;
    public int skill = 5;
    
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
        //Debug.Log("Compat = " + this.name + " -> " + otherNPC.name + " = " + comp);
        return comp;
    }

    public void killNPC()
    {   
        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));
        controllerScript.fireEmployee(this);
        Debug.Log(controllerScript.NPCList.Count);
        controllerScript.NPCList.Remove(this.gameObject);
        controllerScript.employeeNames.Remove(this.name);
        controllerScript.getGraph().removeNode(this);
        Debug.Log(controllerScript.NPCList.Count);
        DestroyImmediate(this.gameObject,true);
    }

    public void TransferNPC() {

        GameObject transfer = GameObject.Find("TransferEvent");
        TransferManager transferScript = transfer.GetComponent<TransferManager>();
        transferScript.transferToHost(name,ethnicity,gender,age,position,teamwork,skill);
        killNPC();
    }

    /**
     * returns a gender seed which will be used to determine diversity of a team
     */ 
    public int getGenderSeed()
    {
        if (gender == "male")
            return UnityEngine.Random.Range(4, 7);

        else
            return UnityEngine.Random.Range(0, 4);
    }

    /**
     * returns a age seed which will be used to determine diversity of a team
     */
    public int getAgeSeed()
    {
        //Returns a range between 0 - 5
        return ((int.Parse(age) / 7) - 2);
    }

    /**
     * returns a age seed which will be used to determine diversity of a team
     */
    public int getEthnicitySeed(string[] ethnicities)
    {
        int pos = Array.IndexOf(ethnicities, ethnicity);
        return pos;
    }

  

    
}
