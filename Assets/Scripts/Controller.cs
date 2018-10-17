using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the main game controller.

public class Controller : MonoBehaviour {

    public List<GameObject> NPCList = new List<GameObject>();
    public float timedEventA = 5f;
    public float conflictEventTimer = 20f;
    EventManager eventManager = new EventManager();
    int numEmployees = 1;
    float lossTime = 4;
    float CVupdate = 7;

    // Tracks he currently active event.
    private CustomEvent _currentEvent;

    public GameObject proposalBoxPrefab;
    public GameObject hireBoxPrefab;
    public GameObject currentTaskPrefab;
    public GameObject conflictPrefab;
    public GameObject transferPrefab;

    // Track the world controller:
    public GameObject worldControllerObj;

    public GameObject scrollView;

    public int diversity;
    public int happinessIncrement;
    public int skillAve;
    public int teamWorkAve;

    // Track the tilemap:

    public List<ProposalEvent> pEvents = new List<ProposalEvent>();

    public List<string> employeeNames = new List<string>() {"CEO"};

    public InteractionGraph employeeRelationships = new InteractionGraph();

    public Dictionary<string, int> diversities = new Dictionary<string, int>();
    public List<Stats> charStats = new List<Stats>();


    void Start()
    {

        proposalBoxPrefab = GameObject.Find("EventCanvas/EventPanel");
        proposalBoxPrefab.SetActive(false);
        hireBoxPrefab = GameObject.Find("EventCanvas/HirePanel");
        hireBoxPrefab.SetActive(false);
        conflictPrefab = GameObject.Find("EventCanvas/ConflictPrefab");
        conflictPrefab.SetActive(false);
        transferPrefab = GameObject.Find("EventCanvas/TransferPanel");
        transferPrefab.SetActive(false);
        currentTaskPrefab.SetActive(false);

        setDiversities();
        happinessIncrement = 1;

        // Create the world controller:
        //worldControllerObj = new GameObject();
        //worldControllerObj.AddComponent(typeof(WorldController));
        ////worldControllerObj.GetComponent(typeof(WorldController));

    }

    void Update()
    {
        Timer();
	}


    void doConflict()
    {
        bool conflict = false;
        if(employeeRelationships.numNodes() > 1)
        {
            ConflictScript script = conflictPrefab.GetComponent<ConflictScript>();
            if (script.generateConflict())
            {
                conflict = true;
                conflictPrefab.SetActive(true);
            }
        }
        if(!conflict)
        {
            conflictEventTimer = 20f;
        }
    }


    public void addAvailableEmployee(string employee)
    {
        employeeNames.Add(employee);
    }

  
    
    void doProposalEvent() {
        int i = 0;
        while (employeeNames.Count != 0)
        {
            Debug.Log("" + i);
            pEvents.Add(eventManager.getProposalEvent(employeeNames));
            employeeNames = eventManager.getEmployeesToBeRemoved(employeeNames);
        }

        ScrollViewAdapter viewAdapter = (ScrollViewAdapter)scrollView.GetComponent(typeof(ScrollViewAdapter));
        viewAdapter.OnRecieveNewProposals(pEvents);
        pEvents.Clear();
        proposalBoxPrefab.SetActive(true);



    }

    void Timer()
    {

        timedEventA -= Time.deltaTime;

        if (timedEventA <= 0.0f)
        {
            // Debug.Log("Bye There");
            updateHappinessDispositions();
            doProposalEvent();
            updateHappiness();
            timedEventA = 100000f;
        }


        conflictEventTimer -= Time.deltaTime;
        if (conflictEventTimer <= 0.0f)
        {
            doConflict();
            conflictEventTimer = 100000f;
        }


        lossTime -= Time.deltaTime;
        if (lossTime < 0)
        {
            //Lose in captial over time
            foreach (GameObject npc in NPCList)
            {
                Stats statsScript = npc.GetComponent<Stats>();
                switch(statsScript.position.ToString())
                {
                    case "Intern" :
                        ScoreScript.money -= 10;
                        break;
                    case "Entry":
                        ScoreScript.money -= 20;
                        break;
                    case "Junior":
                        ScoreScript.money -= 40;
                        break;
                    case "Senior":
                        ScoreScript.money -= 60;
                        break;
                    case "Specialist":
                        ScoreScript.money -= 80;
                        break;
                }
            }
            lossTime = 4;
        }

        CVupdate -= Time.deltaTime;
        if (CVupdate < 0 && hireBoxPrefab != null)
        {

            int CVcount = hireBoxPrefab.transform.childCount;
            for (int x = 1; x < CVcount; x++) {

                GameObject cvChild = hireBoxPrefab.transform.GetChild(x).gameObject;

                if (cvChild.activeInHierarchy == false) {

                    cvChild.GetComponent<CVscript>().GenerateCV();
                    cvChild.SetActive(true);
                    break;

                }

            }
            CVupdate = 7;
        }
    }

    public void doEvent(bool execute)
    {
        Debug.Log("clicked");
        if (execute)
        {
            _currentEvent.consequence();
        }
        else
        {

        }
        proposalBoxPrefab.SetActive(false);
    }

    public void createProceduralNPC(string name, string gender, string age, string ethnicity, string position, int skill, int teamwork)
    {
        hireBoxPrefab = GameObject.Find("HirePanel");
        GameObject randomNPC =
            Instantiate(Resources.Load("CharacterGeneration/CustomCharacter"),
            new Vector3(1, 0, 1),
            Quaternion.identity) as GameObject;
        //Stats statScript = randomNPC.GetComponent<Stats>();
       

        string bodyName = "";
        string hairName = "";

        // Load the body
        switch (Random.Range(1,3))
        {
            case 1:
                bodyName = "body_pale";
                break;
            case 2:
                bodyName = "body_dark";
                break;
        }
        
        // Load the hair
        if (gender == "Male")
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    hairName = "hair_anime_white";
                    break;
                case 2:
                    hairName = "hair_bob_white";
                    break;
            }
        }
        else
        {

            switch (Random.Range(1, 2))
            {
                case 1:
                    hairName = "hair_ponytail_white";
                    break;
            }

        }
        Color hairColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        
        //  Setup the shirt
        Color shirtColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        
        // Setup the pants
        Color pantsColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        
        // Set data into character stats
        Stats statsScript = randomNPC.GetComponent<Stats>();
        statsScript.name = name;
        statsScript.pantsColor = pantsColor;
        statsScript.shirtColor = shirtColor;
        statsScript.hairColor = hairColor;
        statsScript.bodyName = bodyName;
        statsScript.hairName = hairName;
        statsScript.gender = gender;
        statsScript.ethnicity = ethnicity;
        statsScript.age = age;
        statsScript.position = position;
        statsScript.teamwork = teamwork;
        statsScript.skill = skill;
        charStats.Add(statsScript);
        setHappinessIncrement();
        updateDiversity();
        setSkillTeamwork();

        randomNPC.name = name;

        randomNPC.transform.Find("Opperations Panel/Panel/Text").GetComponent<Text>().text =
            "Name: " + name + "\n" +
            "Gender " + gender + "\n" +
            "Age: " + age + "\n" +
            "Ethnicity: " + ethnicity + "\n" +
            "Position: " + position + "\n" +
            "Skill: " + skill.ToString() + "\n" +
            "Teamwork: " + teamwork.ToString() + "\n";
            

        NPCList.Add(randomNPC);
        employeeNames.Add(name);
        employeeRelationships.addNode(statsScript);
    }

    // Create a new NPC
    public void createNPC(int seed)
    {

        int x = 1;
        int y = 0;
        numEmployees++;
        Debug.Log("Creating NPC at " + x + " " + y);

        // Basic setup:
        GameObject npc = new GameObject();
        npc.transform.position = new Vector3(x, y, 1);
        npc.AddComponent<SpriteRenderer>();
        npc.AddComponent<WorldObject>();
        npc.AddComponent<Rigidbody2D>();
        npc.AddComponent<EdgeCollider2D>();
        npc.AddComponent<NPCMovement>();

        // Create and add the sprite:
        //@@TODO: randomly generate the NPC.
        Sprite tex = Resources.Load<Sprite>("dude");
        SpriteRenderer spriteRenderer = npc.GetComponent<SpriteRenderer>();

        if (seed == 0)
        {

            tex = Resources.Load<Sprite>("DarkFemale");
            npc.name = "Employee-DarkFemale";
            employeeNames.Add("DarkFemale");

        }
        else if (seed == 1)
        {

            tex = Resources.Load<Sprite>("GingerMale");
            npc.name = "Employee-GingerMale";
            employeeNames.Add("GingerMale");

        }
        else if (seed == 2)
        {

            tex = Resources.Load<Sprite>("Goku");
            npc.name = "Employee-Goku";
            employeeNames.Add("Goku");

        }
        else if (seed == 3)
        {

            tex = Resources.Load<Sprite>("AsianMale");
            npc.name = "Employee-AsianMale";
            employeeNames.Add("AsianMale");

        }
        //Sprite s = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0, 0));
        spriteRenderer.sprite = tex;
        //spriteRenderer.sortingLayerName = "Players";

        // Set the position of the edge collider to the feet of the sprite.
        EdgeCollider2D collider = npc.GetComponent<EdgeCollider2D>();
        //collider.offset = new Vector2(0, -1.0625f);

        Vector2[] colliderpoints;
        colliderpoints = collider.points;
        colliderpoints[0] = new Vector2(-0.05501652f, 0.09463114f);
        colliderpoints[1] = new Vector2(0.02647161f, 0.1021858f);
        collider.points = colliderpoints;

        Debug.Log(collider.points[0]);

        // Set the rigid body to be kinematic.
        Rigidbody2D rigidbody = npc.GetComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.gravityScale = 0;
        rigidbody.angularDrag = 0;
        rigidbody.mass = 1;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        //Set the size of the sprite to fit the map.
        npc.transform.localScale = new Vector2(1f, 1f);

    }

    private void updateHappinessDispositions()
    {
        int avgDisp = 0;
        foreach(InteractionGraph.Relationship edge in employeeRelationships.getEdges())
        {
            avgDisp += edge.getDisposition();
        }
        avgDisp = avgDisp / employeeRelationships.getEdges().Count;

        int incHappiness = avgDisp - 10;

        Debug.Log("inc = " + incHappiness);

        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));
        scoreScript.happiness += incHappiness;

    }

    private void updateHappiness() {

        if (happinessIncrement > 50) {
            happinessIncrement = 50;
        } else if (diversity / 4 == 0) {
            happinessIncrement += 1;
        } else {
            happinessIncrement += diversity / 4;
        }
        
        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));
        scoreScript.happiness += happinessIncrement;

    }

    public void updateDiversity() {

        diversity = 0;

        CVscript cv = new CVscript();

        
        foreach (Stats stat in charStats) {

            if (diversities[stat.gender] == 0) {
                diversities[stat.gender] += 1;
                diversity += 1;
            }

        }

        foreach (Stats stat in charStats)
        {

            if (diversities[stat.ethnicity] == 0)
            {
                diversities[stat.ethnicity] += 1;
                diversity += 1;
            }

        }
    }

    public void setHappinessIncrement() {

        happinessIncrement = happinessIncrement + 1;
        happinessIncrement = happinessIncrement + (12 - diversity);
        
    }

    public void fireEmployee(Stats firee)
    {
        GameObject score = GameObject.Find("Score");
        ScoreScript scoreScript = (ScoreScript)score.GetComponent(typeof(ScoreScript));
        scoreScript.happiness -= 50;

        diversities[firee.gender] -= 1;
        diversities[firee.ethnicity] -= 1;

        if (diversities[firee.gender] == 0) {
            diversity -= 1;
        }

        if (diversities[firee.ethnicity] == 0)
        {
            diversity -= 1;
        }

        setSkillTeamwork();
    }

    private void setDiversities()  {
        CVscript cv = new CVscript();

        foreach (string gender in cv.genders)
        {
            diversities.Add(gender, 0);
        }

        foreach (string country in cv.ethnicites)
        {
            diversities.Add(country, 0);
        }
    }

    public InteractionGraph getGraph()
    {
        return employeeRelationships;
    }

    public void setSkillTeamwork() {
        int skill = 0;
        int teamwork = 0;
        foreach (Stats stat in charStats) {
            skill += stat.skill;
            teamwork += stat.teamwork;
        }
        skillAve = skill / charStats.Count;
        teamWorkAve = teamwork / charStats.Count;
    }
}
