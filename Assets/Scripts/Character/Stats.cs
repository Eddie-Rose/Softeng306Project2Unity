using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int seed;
    public int happiness = 100;
    public string name;
    public string ethnicity;
    public string gender;
    public string age;
    public string position;
    public int teamwork;
    public int skill;
    public List<Stats> friends = new List<Stats>();
  

    //void Update() {}

    void Start() {

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
            comp += 1;
            //comp += Random.Range(-1, 5);
        }
        else {
            //comp += Random.Range(-2, 4);
        }

        comp += ((teamwork + otherNPC.teamwork) / 2);

        return comp;
    }

}

