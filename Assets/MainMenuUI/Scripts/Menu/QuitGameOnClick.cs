using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Same functionality as QuitApplication (temporary duplicate)  
public class QuitGameOnClick : MonoBehaviour {

    public void Quit()
    {
        //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
        #endif

        //If we are running in the editor
        #if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
