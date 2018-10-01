using System;
using UnityEngine;

public class CVGenerator : MonoBehaviour
{
    private string name;
    private Gender gender;
    private byte age;
    private Nationality nationality;
    private DateTime dob;
    private string summary;
    private float skill;
    private float teamwork;


    // Use this for initialization
    void Start()
    {
        rollStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void rollStats()
    {
        //generate a random minimum skill threshold from 10 - 15
        double total = 10 + new System.Random().NextDouble() * 5;

        teamwork = 0;
        skill = 0;

        //generate ("roll") random skill and teamwork values from 0 to 10 until the sum is greater than the minimum threshold.
        while(teamwork + skill < total)
        {
            teamwork = (float) new System.Random().NextDouble() * 10;
            skill = (float)new System.Random().NextDouble() * 10;
        }

        //create a random age number for the person.
        age = (byte) new System.Random().Next(19, 55);

        //set the date of birth.
        int year = DateTime.Now.Year - age;
        int dayOfYear = new System.Random().Next(1, 365);

        dob = new DateTime(year, 1, 1);
        dob.AddDays(dayOfYear - 1);

        //roll the gender.
        gender = (Gender) new System.Random().Next(1, 2);

        //roll the nationality.
        nationality = (Nationality) new System.Random().Next(0, 3);
    }
}

enum Gender
{
    UNDEFINED, MALE, FEMALE
}

enum Nationality
{
    NEW_ZEALANDER, CANADIAN, AMERICAN, FRENCH
}
