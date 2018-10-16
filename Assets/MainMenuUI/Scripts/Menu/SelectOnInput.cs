using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// This class ensures a button / UI objcet is selected when a gamepad/keyboard is being used
public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedGameObject;

    private bool buttonSelected;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false) {
            eventSystem.SetSelectedGameObject(selectedGameObject);
            buttonSelected = true;
        }
	}

    private void OnDisable() {
        buttonSelected = false;
    }
}
