using System;
using UnityEngine;

public class CVGenerator : MonoBehaviour
{
    private string name;
    private Gender gender;
    private byte age;
    private Nationality nationality;
    private DateTime time;
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
        double total = 10 + new System.Random().NextDouble() * 5;
    }
}

enum Gender
{
    MALE, FEMALE, UNDEFINED
}

enum Nationality
{
    NEW_ZEALANDER, CANADIAN, AMERICAN, FRENCH
}
