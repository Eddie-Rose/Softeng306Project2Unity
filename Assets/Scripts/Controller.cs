using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is the main game controller.

public class Controller : MonoBehaviour {

    public List<GameObject> NPCList = new List<GameObject>();
    public float timedEventA = 5f;
    EventManager eventManager = new EventManager();
    int numEmployees = 1;

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
        DeductMoney();
	}

    float lossTime = 4;

    void DeductMoney()
    {
        lossTime -= Time.deltaTime;
        if(lossTime < 0)
        {
            ScoreScript.money -= (NPCList.Count + 1) * 200;
            lossTime = 4;
        }
    }

    float conflictTime = 20;

    void ConflictTimer()
    {
        conflictTime -= Time.deltaTime;
        if (conflictTime < 0)
        {
            doConflictEvent();
            conflictTime = 20;
        }
    }

    void doConflictEvent()
    {

    }


    public void addAvailableEmployee(string employee)
    {
        employeeNames.Add(employee);
    }

  

    void doProposalEvent() {

        List<string> employeeToBeDeleted = new List<string>();
        foreach(string employee in employeeNames)

        {
            pEvents.Add(eventManager.getProposalEvent(employee));
            employeeToBeDeleted.Add(employee);

        }
        foreach(string employee in employeeToBeDeleted)
        {
            employeeNames.Remove(employee);
        }
        employeeToBeDeleted.Clear();
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
            doProposalEvent();
            updateHappiness();
            timedEventA = 100000f;
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

        GameObject randomNPC =
            Instantiate(Resources.Load("CharacterGeneration/CustomCharacter"),
            new Vector3(1, 0, 1),
            Quaternion.identity) as GameObject;

        //Stats statScript = randomNPC.GetComponent<Stats>();
        

        Transform shirtObject = randomNPC.transform.GetChild(0);
        Transform bodyObject = randomNPC.transform.GetChild(1);
        Transform hairObject = randomNPC.transform.GetChild(2);
        Transform pantsObject = randomNPC.transform.GetChild(3);


        string bodyName = "";
        string hairName = "";
        string shirtName = "";
        string pantsName = "";

        switch (Random.Range(1, 3))
        {
            case 1:
                bodyName = "body_pale";
                break;
            case 2:
                bodyName = "body_dark";
                break;
        }
        bodyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + bodyName);


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
        hairObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Hairs/" + hairName);
        Color random = new Color(Random.value, Random.value, Random.value, 1.0f);
        hairObject.GetComponent<SpriteRenderer>().color = random;

        switch (Random.Range(1, 5))
        {
            case 1:
                shirtName = "shirt_blue";
                break;
            case 2:
                shirtName = "shirt_limegreen";
                break;
            case 3:
                shirtName = "shirt_pink";
                break;
            case 4:
                shirtName = "shirt_white";
                break;
        }
        shirtObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Shirts/" + shirtName);
        shirtObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);


        switch (Random.Range(1, 3))
        {
            case 1:
                pantsName = "pants_blue";
                break;
            case 2:
                pantsName = "pant_dark";
                break;
        }
        pantsObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CharacterGeneration/Pants/" + pantsName);
        pantsObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);

        //set data into npc stats
        Stats statsScript = randomNPC.GetComponent<Stats>();
        statsScript.name = name;
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
        statsScript.haircolor = random;

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

        foreach (Stats stat in charStats) {

            if (diversities[stat.ethnicity] == 0) {
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
