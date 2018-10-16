﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager{

    public ProposalEvent getProposalEvent(string employee) {

        int eventRisk = Random.Range(1, 10);
        int eventReward = Random.Range(1, 10);
        float eventChance = Random.Range(0f, 1f);
        string[] projectArray = new string[] { "Release new innovative project.",
            "Outsource all phone opperations.",
            "Redesign current products.",
            "Horizontal intergration through buy out.",
            "Sell assets for temporary gain, aquire new assets later.",
            "Invest in research for potiential future products.",
            "Sell stocks, raise funds.",
            "Temporary partnership with company in same sector."
        };
        string eventDescription = "";
        eventDescription += projectArray[Random.Range(0, projectArray.Length)] + "\n";



        if (eventChance <= 0.33)
        {

            eventDescription += "this is low risk project with a low chance of failure";

        }
        else if (eventChance > 0.33 && eventChance <= 0.66)
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


        if (eventReward <= 3)
        {

            eventDescription += "The success of this project will be only slightly benificial to the company";

        }
        else if (eventReward > 3 && eventReward <= 6)
        {

            eventDescription += "The success of this project will be moderatly benificial to the company";

        }
        else
        {

            eventDescription += "The success of this project will yield great benifits for the company";

        }

        eventDescription += "\n";
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

        ProposalEvent pEvent = new ProposalEvent(employee, eventDescription, eventRisk,eventReward,eventChance, 15.0f, 10.0f);
        return pEvent;
    }  
}
