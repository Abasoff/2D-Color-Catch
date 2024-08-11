using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // Reference to the pause menu UI GameObject
    public GameObject pauseMenuUI;
    // Boolean to track if the game is paused
    private bool isPaused = false;

    private void Start()
    {
        // Ensure the pause menu is hidden at the start
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between pausing and resuming the game
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Method to pause the game
    public void PauseGame()
    {
        // Show the pause menu UI
        pauseMenuUI.SetActive(true);
        // Freeze the game time
        Time.timeScale = 0f;
        // Set the paused state to true
        isPaused = true;
    }

    // Method to resume the game
    public void ResumeGame()
    {
        // Hide the pause menu UI
        pauseMenuUI.SetActive(false);
        // Resume the game time
        Time.timeScale = 1f;
        // Set the paused state to false
        isPaused = false;
    }

    // Method to show the pause menu
    public void ShowPauseMenu()
    {
        PauseGame();
    }

    // Method to restart the current level
    public void RestartLevel()
    {
        // Resume the game time
        Time.timeScale = 1f;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to load the main menu scene
    public void LoadMainMenu()
    {
        // Resume the game time
        Time.timeScale = 1f;
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Log a message to the console
        Debug.Log("Quitting game...");
        // Quit the application
        Application.Quit();
    }
}
