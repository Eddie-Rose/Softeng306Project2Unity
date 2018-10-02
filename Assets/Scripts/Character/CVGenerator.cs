using System;
using UnityEngine;

public class CVGenerator : MonoBehaviour
{
    public string name;
    public Gender gender;
    public byte age;
    public Nationality nationality;
    public DateTime dob;
    public string summary;
    public float skill;
    public float teamwork;

    private static string[] names = 
    {
        "John Clark",
        "Jennifer Adams",
        "Vanessa Wu",
        "Tane Phillips",
        "Henri DuPont",
        "Abigail Bantham"
    };

    private static string[] summaries = 
    {
        "I am a very social person who enjoys working as part of a diverse and interesting team. I have strong communication and leadership skills. I have a degree in Marketing.",
        "I am a focused person who excels at producing high quality work. My area of expertise is in marketing and I am very good at presenting an idea in a way which is pleasing to the target audience.",
        "I am a calm and fair person. I have experience working in HR and especially in conflict mediation. I believe that a harmonious workforce is a productive workforce.",
        "I am a hard-working and driven person who will always give 110% to any team and/or project that I am a part of. I work best as part of a small and focused team.",
        "I am an independent worker who loves to overcome challenges in my work. I am great at taking initiative and am happiest when I am given the freedom to work my way.",
        "I am a laid-back and relaxed member of the workforce who finds great pleasure in working as part of a large and varied team. I love to get involved in social activites in addition to my work responsibilities."
    };



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

        //assign a name.
        name = names[new System.Random().Next(names.Length)];

        Console.WriteLine(name);


        //assign a summary.
        summary = summaries[new System.Random().Next(summaries.Length)];


        Console.WriteLine(summary);
    }
}

public enum Gender
{
    UNDEFINED, MALE, FEMALE
}

public enum Nationality
{
    NEW_ZEALANDER, CANADIAN, AMERICAN, FRENCH
}
