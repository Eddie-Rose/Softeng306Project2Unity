using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel 
    public GameObject helpPanel;
    public Animator optionsButton;

    private Animator animatorTest;
    private Animation animatorTest1;

    private GameObject activePanel;                         
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;



    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    public void Start()
    {
        SetSelection(menuPanel);

    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
        optionsPanel.SetActive(true);
        optionsTint.SetActive(true);
        //menuPanel.SetActive(false);
        //optionsButton.GetComponent<Animator>().Play("Normal", 1);
        //EventSystem.current.SetSelectedGameObject(null);
        SetSelection(optionsPanel);

    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        //EventSystem.current.SetSelectedGameObject(null);
        //menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
        SetSelection(menuPanel);
    }

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
        menuPanel.SetActive (false);

	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
        SetSelection(pausePanel);
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

    //Call this function to activate and display the Pause panel during game play
    public void ShowHelpPanel()
    {
        helpPanel.SetActive(true);
        optionsTint.SetActive(true);
        //menuPanel.SetActive(false);
        SetSelection(helpPanel);
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HideHelpPanel()
    {
        //menuPanel.SetActive(true);
        helpPanel.SetActive(false);
        optionsTint.SetActive(false);

    }
}
