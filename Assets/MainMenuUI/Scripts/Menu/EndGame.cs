using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    private ShowPanels showPanels;                      //Reference to the ShowPanels script used to hide and show UI panels
    private bool isPaused;                              //Boolean to check if the game is paused or not
    private StartOptions startScript;                   //Reference to the StartButton script
    private bool gameWin = false;

    //Awake is called before Start()
    void Awake()
    {
        //Get a component reference to ShowPanels attached to this object, store in showPanels variable
        showPanels = GetComponent<ShowPanels>();
        //Get a component reference to StartButton attached to this object, store in startScript variable
        startScript = GetComponent<StartOptions>();
    }

    // Update is called once per frame
    void Update()
    {

        //Check if the user has earned enough money to "win"
        if (ScoreScript.money > 100000 && !isPaused && !startScript.inMainMenu) {
            //Call the DoEndGame function to end the game
            Debug.Log("Game won");
            gameWin = true;
            DoEndGame();
        } else if (ScoreScript.money < 0 && !isPaused && !startScript.inMainMenu) {
            Debug.Log("Game lost");
            gameWin = false;
            DoEndGame();
        }
        //If the button is pressed and the game is paused and not in main menu
        //else if (Input.GetButtonDown("Cancel") && isPaused && !startScript.inMainMenu)
        //{
        //    //Call the UnPause function to unpause the game
        //    UnEndGame();
        //}

    }

    // Function that carries out ending the game
    public void DoEndGame()
    {
        //Set isPaused to true
        isPaused = true;
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        if (gameWin) {
            showPanels.ShowWinGamePanel();
        } else {
            showPanels.ShowLoseGamePanel();
        }
        //call the ShowPausePanel function of the ShowPanels script
        //showPanels.ShowEndGamePanel();
    }

    // Restarts the game
    public void UnEndGame()
    {
        ScoreScript.money = 0;

        // Reloads the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Set isPaused to false
        isPaused = false;

        //Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        Time.timeScale = 1;

        // Removies the end game panels
        showPanels.HidePausePanel();
        showPanels.HideWinGamePanel();
        showPanels.HideLoseGamePanel();
    }

    public void Continue() {
        Time.timeScale = 1;
    }


}
