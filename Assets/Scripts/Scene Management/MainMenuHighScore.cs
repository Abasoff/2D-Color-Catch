using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour
{
    // UI Text components to display high score and current score
    public Text highScoreText;
    public Text currentScoreText;

    // Keys to store and retrieve high score and current score from PlayerPrefs
    private const string HIGH_SCORE_KEY = "HighScore";
    private const string CURRENT_SCORE_KEY = "CurrentScore";

    private void Start()
    {
        // Retrieve the high score from PlayerPrefs, defaulting to 0 if not found
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);

        // Retrieve the current score from PlayerPrefs, defaulting to 0 if not found
        int currentScore = PlayerPrefs.GetInt(CURRENT_SCORE_KEY, 0);

        // Update the UI text components with the retrieved scores
        highScoreText.text = "High Score: " + highScore;
        currentScoreText.text = "Current Score: " + currentScore;
    }
}
