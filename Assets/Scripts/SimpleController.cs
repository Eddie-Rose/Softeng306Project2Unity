using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    public void ChangeColor() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = Color.green;
        Debug.Log("Color Changed, Event Detected");

    }
}
