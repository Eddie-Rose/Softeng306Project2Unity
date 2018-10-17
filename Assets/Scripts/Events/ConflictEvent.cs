using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * An event which can show conflicts between employees.
 */
public class ConflictEvent : CustomEvent
{
    public int _cost;

    public ConflictEvent(int cost)
    {
        _cost = cost;
    }
    public override void consequence()
    {
        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));

        ScoreScript.money -= _cost;
    }
}
