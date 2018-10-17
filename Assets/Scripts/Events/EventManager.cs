using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager{

    public ProposalEvent getProposalEvent(string employee) {

        int eventRisk = Random.Range(1, 10);
        int eventReward = Random.Range(1, 10);
        int eventTeam = Random.Range(0, 3);
        int eventSkill = Random.Range(0, 3);
        
        string[] projectArray = new string[] { "Release new innovative project.",
            "Outsource all phone opperations.",
            "Redesign current products.",
            "Horizontal intergration through buy out.",
            "Sell assets for temporary gain, aquire new assets later.",
            "Invest in research for potential future products.",
            "Sell stocks, raise funds.",
            "Temporary partnership with company in same sector."
        };
        string eventDescription = "";
        eventDescription += projectArray[Random.Range(0, projectArray.Length)] + "\n";

        float eventChance = Random.Range(0f, 1f);

        GameObject controller = GameObject.Find("ControllerObject");
        Controller controllerScript = (Controller)controller.GetComponent(typeof(Controller));

        if (eventChance <= 0.33f)
        {

            eventDescription += "this is low risk project with a low chance of failure";

        }
        else if (eventChance > 0.33f && eventChance <= 0.66f)
        {

            eventDescription += "this is moderatly risky project with a good chance of failing";

        }
        else {

            eventDescription += "this is a very risky project, the chances of failure are high";

        }

        eventDescription += "\n";

        //------------------------------------------------------------------------------------------



        if (eventRisk <= 3)
        {

            eventDescription += "Failure of this project will result in minor damages";

        }
        else if (eventRisk > 3 && eventRisk <= 6)
        {

            eventDescription += "Failure of this project will deal considerable damage to the Comapny";

        }
        else
        {

            eventDescription += "Failure of this project is detrimental to the company";

        }

        eventDescription += "\n";

        //-------------------------------------------------------------------------------------------

        if (eventTeam == 2)
        {

            eventDescription += "The success of this project will require employees to have high teamwork";
            if (controllerScript.teamWorkAve > 7)
            {
                eventChance += 0.2f;
            } else
            {
                eventChance -= 0.2f;
            }

        }
        else if (eventTeam == 1)
        {

            eventDescription += "The success of this project will require employees to have moderate teamwork";
            if (controllerScript.teamWorkAve > 4)
            {
                eventChance += 0.1f;
            }
            else
            {
                eventChance -= 0.1f;
            }

        }
        else
        {

            eventDescription += "The success of this project is not affected by teamwork";

        }

        eventDescription += "\n";

        //-------------------------------------------------------------------------------------------

        if (eventSkill == 2)
        {

            eventDescription += "The success of this project will require employees to have high skill";
            if (controllerScript.skillAve > 7)
            {
                eventChance += 0.2f;
            }
            else
            {
                eventChance -= 0.2f;
            }

        }
        else if (eventSkill == 1)
        {

            eventDescription += "The success of this project will require employees to have moderate skill";
            if (controllerScript.skillAve > 4)
            {
                eventChance += 0.1f;
            }
            else
            {
                eventChance -= 0.1f;
            }

        }
        else
        {

            eventDescription += "The success of this project is not affected by skill";

        }

        eventDescription += "\n";

        //-------------------------------------------------------------------------------------------

        if (eventRisk <= 3)
        {

            eventDescription += "Failure of this project will result in minor damages";

        }
        else if (eventRisk > 3 && eventRisk <= 6)
        {

            eventDescription += "Failure of this project will deal considerable damage to the Comapny";

        }
        else
        {

            eventDescription += "Failure of this project is detrimental to the company";

        }

        eventDescription += "\n";

        //-------------------------------------------------------------------------------------------

        if (employee != null)
        {
            eventDescription += "Proposed by: " + employee;
            eventDescription += "\n";
        }
        else
        {
            eventDescription += "Proposed by: CEO";
            eventDescription += "\n";
        }

        eventDescription += "Estimated reward: $" + eventReward + "k\n";
        eventDescription += "Estimated loss: $" + eventRisk + "k\n";


        ProposalEvent pEvent = new ProposalEvent(employee, eventDescription, eventRisk,eventReward,eventChance, 15.0f, 10.0f);
        return pEvent;
    }

    public ConflictEvent getConflictEvent(int cost)
    {
        ConflictEvent ce = new ConflictEvent(cost);
        return ce;
    }

}
