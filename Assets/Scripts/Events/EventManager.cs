using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager{

    //Employees that propose a task, to be removed after each iteration
    List<string> employeesToBeDeleted = new List<string>();


    //Main get proposal event, randomly generates an event
    public ProposalEvent getActualProposalEvent(List<string> employees) {

        int eventRisk = Random.Range(1, 10);
        int eventReward = Random.Range(1, 10);
        int eventTeam = Random.Range(0, 3);
        int eventSkill = Random.Range(0, 3);
        

        //Main project description
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


        // Chance of failure
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

        //Chance of sucess based on teamwork ability
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

        //  Chance of success based of ability
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


        //Describe event risk's effect to the company
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

        //Name who is it proposed by
        eventDescription += "Proposed by:";
        int count = 0;
        foreach (string employee in employees)
        {
            if (count == 0)
                eventDescription += " " + employee;
            else
                eventDescription += ", " + employee;
            count++;
        }
        eventDescription += "\n";

        //Name the potential reward/ loss
        eventDescription += "Estimated reward: $" + eventReward + "k\n";
        eventDescription += "Estimated loss: $" + eventRisk + "k\n";



        //Create and return the new event
        ProposalEvent pEvent = new ProposalEvent(employees, eventDescription, eventRisk,eventReward,eventChance, 35.0f, 10.0f);
        return pEvent;
    }

    //Generate proposal based on employee diersity
    public ProposalEvent getProposalEvent(List<string> employees)
    {
        //CEO does not depend on team diversity, he is different entity
        foreach(string employee in employees)
        {
            if (employee == "CEO")
            {
                employeesToBeDeleted.Add(employee);
                return getActualProposalEvent(employeesToBeDeleted);
            }
        }

        //If only one employee left generate his own event
        if (employees.Count == 1)
        {
            employeesToBeDeleted.Add(employees[0]);
            return getActualProposalEvent(employeesToBeDeleted);
        }

        //See team diversity and generate proposals based on diversty
        else
        {

            //Get the employee to be compared's stats 
            GameObject employeeGameObject1 = GameObject.Find(employees[0]).gameObject;
            Stats employeeScript1 = employeeGameObject1.GetComponent<Stats>();

            employeesToBeDeleted.Add(employees[0]);
            employees.Remove(employees[0]);

            //Loop through all employee in team to compare similarity between 2 employees
            foreach(string employee in employees)
            {

                //Get the next employee stats script
                GameObject employeeGameObject2 = GameObject.Find(employee).gameObject;
                Stats employeeScript2 = employeeGameObject2.GetComponent<Stats>();

                //Random generator, higher priority on diversity(60%), age(30%), gender(10%)
                int chance = Random.Range(1, 11);

                //Compare similarity based off gender
                if (chance == 1)
                {
                    //Compare gender similarity seed
                    if (employeeScript1.genderSeed == employeeScript2.genderSeed)
                    {
                        employeesToBeDeleted.Add(employee);
                    }
                }

                //Compare similarity based off age
                else if ((chance > 1) && (chance <= 4))
                {
                    //Compare gender age seed
                    if (employeeScript1.ageSeed == employeeScript2.ageSeed)
                    {
                        employeesToBeDeleted.Add(employee);
                    }

                }

                //Compare similarity based off employee
                else
                {
                    //Compare gender ethnicity seed
                    if (employeeScript1.ethnicitySeed == employeeScript2.ethnicitySeed)
                    {
                        employeesToBeDeleted.Add(employee);
                    }
                } 

            }

            //Generate actual proposal based
            return getActualProposalEvent(employeesToBeDeleted);
        }


        
    }

    //Clear list after each iteration
    public List<string> getEmployeesToBeRemoved(List<string> employees)
    {
        foreach (string employee in employeesToBeDeleted)
        {
            employees.Remove(employee);
        }


        employeesToBeDeleted = new List<string>();
        return employees;
    }

    public ConflictEvent getConflictEvent(int cost)
    {
        ConflictEvent ce = new ConflictEvent(cost);
        return ce;
    }

}
