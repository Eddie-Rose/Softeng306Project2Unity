using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalEvent : CustomEvent{

    //identifies which risk/reward consenquences are weighted
    public int _risk;
    public int _reward;

    //identifies the chance of a risk/reward consequence occuring
    public float _chance;

    public ProposalEvent(string name, string description, int risk, int reward,float chance)
    {
        _chance = chance;
        _name = name;
        _risk = risk;
        _reward = reward;
        _description = description;

        if(risk == 1)
        {
            _description += "This is preeettty Riiiisky";
        }
        else if(risk == 10)
        {
            _description += "You're fuked";
        }

    }

    public override void consequence() {

        float diceRoll = Random.Range(0f, 1f);
        if (diceRoll > _chance)
        {

            risk();

        }
        else {

            reward();


        }
    }

    private void risk() {


        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));


            ScoreScript.money -= (int) (1000 * _risk * Random.Range(1f, 2f));
            scoreScript.happiness -= (int) (10 * _risk * Random.Range(1f, 2f));




    }

    private void reward() {

        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));



            ScoreScript.money += (int) (1000 * _reward * Random.Range(1f, 2f));
            scoreScript.happiness += (int) (10 * _reward * Random.Range(1f, 2f));


    }
}
