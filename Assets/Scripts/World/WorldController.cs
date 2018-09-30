using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is the world controller.
public class WorldController : MonoBehaviour {

	void Start () {
        Debug.Log("Creating world controller...");

        CreateNPC(32, 0);
        CreateNPC(32, 16);
	}
	
	void Update () {
		
	}

    // Create a new NPC
    void CreateNPC(int x, int y) {
        Debug.Log("Creating NPC at " + x + " " + y);

        // Basic setup:
        GameObject npc = new GameObject();
        npc.transform.position = new Vector3(x, y, 1);
        npc.AddComponent<SpriteRenderer>();
        npc.AddComponent<WorldObject>();

        // Create and add the sprite:
        //@@TODO: randomly generate the NPC.
        Sprite tex = Resources.Load<Sprite>("Placeholder");
        //Sprite s = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0, 0));
        npc.GetComponent<SpriteRenderer>().sprite = tex;
    }
}
