using UnityEngine;

public class OptionMenuManager : MonoBehaviour
{
    // References to UI elements
    public GameObject mainMenuUI; // Attach MainMenu (Canvas) here
    public GameObject infoScreenPanelUI; // Attach InfoScreenPanel here

    private void Start()
    {
        // Show the main menu when the game starts
        ShowMainMenu();
    }

    // Method to show the main menu and hide the info screen panel
    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        infoScreenPanelUI.SetActive(false);
    }

    // Method to show the info screen panel and hide the main menu
    public void ShowOptionsPanel()
    {
        mainMenuUI.SetActive(false);
        infoScreenPanelUI.SetActive(true);
    }

    // Method to exit to the main menu, showing it and hiding the info screen panel
    public void ExitToMainMenu()
    {
        ShowMainMenu();
    }
}
