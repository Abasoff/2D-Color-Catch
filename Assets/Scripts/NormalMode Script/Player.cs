using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Components for rendering and animation
    private SpriteRenderer rend;
    private Animator anim;
    private PauseMenuManager pauseMenuManager;

    // Array of colors the player can change to
    public Color[] colors;
    // String to store the current color code of the player
    public string playerColor;

    // Reference to the ScoreManager and UI Text component for displaying the score
    public ScoreManager scoreManager;
    public Text currentScoreText;

    private void Start()
    {
        // Get the Animator and SpriteRenderer components attached to the player
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

        // Find the PauseMenuManager and ScoreManager in the scene
        pauseMenuManager = FindObjectOfType<PauseMenuManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        // Update the score text at the start
        UpdateScoreText();
    }

    void Update()
    {
        // Change color to red when 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeColor(0, "r");
        }

        // Change color to green when 'G' key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeColor(1, "g");
        }

        // Change color to blue when 'B' key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeColor(2, "b");
        }
    }

    // Method to change the player's color
    private void ChangeColor(int colorIndex, string colorCode)
    {
        // Trigger the change animation
        anim.SetTrigger("change");
        // Set the player's color to the selected color
        rend.color = colors[colorIndex];
        // Update the player's color code
        playerColor = colorCode;
    }

    // Method called when the player collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is an enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemy.enemyColor == playerColor)
        {
            // Destroy the enemy if its color matches the player's color
            enemy.Destruction();
            // Update the score
            scoreManager.UpdateCurrentScore(10);
            // Update the score text
            UpdateScoreText();
        }
        else
        {
            // Show the pause menu if the colors do not match
            pauseMenuManager.ShowPauseMenu();
        }
    }

    // Method to update the score text UI
    private void UpdateScoreText()
    {
        if (currentScoreText != null)
        {
            currentScoreText.text = "Score: " + scoreManager.currentScore;
        }
    }
}
