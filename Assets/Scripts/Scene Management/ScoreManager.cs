using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // UI Text component to display the current score
    public Text currentScoreText;

    // Keys to store and retrieve high score and current score from PlayerPrefs
    public const string HIGH_SCORE_KEY = "HighScore";
    public const string CURRENT_SCORE_KEY = "CurrentScore";

    // Variables to hold the high score and current score
    public int highScore;
    public int currentScore;

    private void Start()
    {
        // Retrieve the high score from PlayerPrefs, defaulting to 0 if not found
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        // Initialize the current score to 0
        currentScore = 0;

        // Update the UI text component with the current score
        UpdateScoreText();
    }

    // Method to update the current score
    public void UpdateCurrentScore(int pointsToAdd)
    {
        // Add the points to the current score
        currentScore += pointsToAdd;

        // Update the UI text component with the new score
        UpdateScoreText();

        // Check if the current score is higher than the high score
        if (currentScore > highScore)
        {
            // Update the high score to the current score
            highScore = currentScore;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        }

        // Save the current score to PlayerPrefs
        PlayerPrefs.SetInt(CURRENT_SCORE_KEY, currentScore);
    }

    // Method to update the UI text component with the current score
    private void UpdateScoreText()
    {
        // Set the text of the UI component to display the current score
        currentScoreText.text = "Score: " + currentScore;
    }
}
