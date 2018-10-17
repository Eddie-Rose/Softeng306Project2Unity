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

    public ProposalEvent(List<string> names, string description, int risk, int reward,float chance, float timeToLive, float timeToCompleteProposal)
    {
        _chance = chance;
        _name = names;
        _risk = risk;
        _reward = reward;
        _description = description;
        _timeToLive = timeToLive;
        _timeToCompleteProposal = timeToCompleteProposal;

    }


    //Reward or deficit depends on random generator and the chance of successes of the project
    public override void consequence() {

        float diceRoll = Random.Range(0.2f, 1f);
        if (diceRoll > _chance)
        {
            reward();
         }
        else {
            risk();
        }
    }

    //Unlucky roll
    private void risk() {


        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));


            ScoreScript.money -= ((int) (1000 * _risk * Random.Range(0f, 1f)) + scoreScript.happiness / 5);
            scoreScript.happiness -= (int) (10 * _risk * Random.Range(0.5f, 1.5f));




    }

    //Lucky roll
    private void reward() {

        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));

            ScoreScript.money += ((int) (1000 * _reward * Random.Range(1f, 2f)) + scoreScript.happiness / 5);
            scoreScript.happiness += (int) (10 * _reward * Random.Range(1f, 2f));


    }
}
