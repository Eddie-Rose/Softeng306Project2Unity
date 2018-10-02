using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is the world controller.
public class WorldController : MonoBehaviour {

	void Start () {
        Debug.Log("Creating world controller...");

        CreateNPC(1, 0);
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
        npc.AddComponent<Rigidbody2D>();
        npc.AddComponent<EdgeCollider2D>();

        // Create and add the sprite:
        //@@TODO: randomly generate the NPC.
        Sprite tex = Resources.Load<Sprite>("Placeholder");
        //Sprite s = Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0, 0));
        npc.GetComponent<SpriteRenderer>().sprite = tex;

        // Set the position of the edge collider to the feet of the sprite.
        EdgeCollider2D collider = npc.GetComponent<EdgeCollider2D>();
        collider.offset = new Vector2(0, -1.0625f);

        // Set the rigid body to be kinematic.
        Rigidbody2D rigidbody = npc.GetComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Kinematic;

        //Set the size of the sprite to fit the map.
        npc.transform.localScale = new Vector2(0.1f, 0.1f);
    }
}
