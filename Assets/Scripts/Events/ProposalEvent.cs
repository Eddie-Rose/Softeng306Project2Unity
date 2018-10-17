using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProposalEvent : CustomEvent{

    //identifies which risk/reward consenquences are weighted
    public int _risk;
    public int _reward;
    public float _timeToLive;
    public float _timeToCompleteProposal;

    //identifies the chance of a risk/reward consequence occuring
    public float _chance;

    public ProposalEvent(string name, string description, int risk, int reward,float chance, float timeToLive, float timeToCompleteProposal)
    {
        _chance = chance;
        _name = name;
        _risk = risk;
        _reward = reward;
        _description = description;
        _timeToLive = timeToLive;
        _timeToCompleteProposal = timeToCompleteProposal;


        

    }

    public override void consequence() {

        float diceRoll = Random.Range(0f, 1f);
        if (diceRoll > _chance)
        {
            reward();

         }
        else {

            risk();

        }
    }

    private void risk() {


        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));


            ScoreScript.money -= (int) (1000 * _risk * Random.Range(0f, 1f));
            scoreScript.happiness -= (int) (10 * _risk * Random.Range(1f, 2f));




    }

    private void reward() {

        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));



            ScoreScript.money += (int) (1000 * _reward * Random.Range(1f, 2f));
            scoreScript.happiness += (int) (10 * _reward * Random.Range(1f, 2f));


    }
}
