using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprites : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Stats stats;
    GameObject character;
    Transform shirtObject;
    Transform bodyObject;
    Transform hairObject;
    Transform pantsObject;

    // animation
    float currentTime = 0;

    void Start () {
        character = this.gameObject;

        // Get a reference to the sprite renderer
        spriteRenderer = character.GetComponent<SpriteRenderer>();

        // Get the character stats
        stats = GetComponent<Stats>();

        shirtObject = character.transform.GetChild(0);
        bodyObject = character.transform.GetChild(1);
        hairObject = character.transform.GetChild(2);
        pantsObject = character.transform.GetChild(3);
    }

    void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > 0.4)
        {
            currentTime = 0;
        }
    }

    public void SetDownSprite()
    {
        // Swap the sprite to 'front'

        hairObject.GetComponent<SpriteRenderer>().sprite 
            = Resources.Load<Sprite>("CharacterGeneration/Hair/" + stats.hairName + "_front");
        hairObject.GetComponent<SpriteRenderer>().color = stats.hairColor;
        
        bodyObject.GetComponent<SpriteRenderer>().sprite 
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName + "_front");

        shirtObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Shirts/shirt_white_front");
        shirtObject.GetComponent<SpriteRenderer>().color = stats.shirtColor;

        pantsObject.GetComponent<SpriteRenderer>().sprite 
            = Resources.Load<Sprite>("CharacterGeneration/Pants/pants_white_front");
        pantsObject.GetComponent<SpriteRenderer>().color = stats.pantsColor;

    }

    public void SetLeftSprite()
    {
        spriteRenderer.flipX = false;

        hairObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Hair/" + stats.hairName);
        hairObject.GetComponent<SpriteRenderer>().color = stats.hairColor;
        hairObject.GetComponent<SpriteRenderer>().flipX = false;

        // Animation
        if (currentTime < 0.2)
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName);
            bodyObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName + "_2");
            bodyObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        shirtObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Shirts/shirt_white");
        shirtObject.GetComponent<SpriteRenderer>().color = stats.shirtColor;
        shirtObject.GetComponent<SpriteRenderer>().flipX = false;

        pantsObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Pants/pants_white");
        pantsObject.GetComponent<SpriteRenderer>().color = stats.pantsColor;
        pantsObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void SetRightSprite()
    {
        spriteRenderer.flipX = true;

        hairObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Hair/" + stats.hairName);
        hairObject.GetComponent<SpriteRenderer>().color = stats.hairColor;
        hairObject.GetComponent<SpriteRenderer>().flipX = true;

        // Animation
        if (currentTime < 0.2)
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName);
            bodyObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName + "_2");
            bodyObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        shirtObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Shirts/shirt_white");
        shirtObject.GetComponent<SpriteRenderer>().color = stats.shirtColor;
        shirtObject.GetComponent<SpriteRenderer>().flipX = true;

        pantsObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Pants/pants_white");
        pantsObject.GetComponent<SpriteRenderer>().color = stats.pantsColor;
        pantsObject.GetComponent<SpriteRenderer>().flipX = true;

    }

    public void SetUpSprite()
    {
        hairObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Hair/" + stats.hairName);
        hairObject.GetComponent<SpriteRenderer>().color = stats.hairColor;

        bodyObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Bodies/" + stats.bodyName);

        shirtObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Shirts/shirt_white");
        shirtObject.GetComponent<SpriteRenderer>().color = stats.shirtColor;

        pantsObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("CharacterGeneration/Pants/pants_white");
        pantsObject.GetComponent<SpriteRenderer>().color = stats.pantsColor;
    }
}
