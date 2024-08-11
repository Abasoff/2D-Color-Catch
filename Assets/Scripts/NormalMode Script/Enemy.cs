using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // The current speed of the enemy
    public float speed;

    // Effects to instantiate upon destruction
    public GameObject effect;
    public GameObject effectTwo;

    // String to store the enemy's color
    public string enemyColor;

    // Reference to the camera's animator
    private Animator camAnim;

    private void Start()
    {
        // Get the Animator component attached to the main camera
        camAnim = Camera.main.GetComponent<Animator>();
    }

    private void Update()
    {
        // Move the enemy to the left at the specified speed
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    // Method to handle the enemy's destruction
    public void Destruction()
    {
        // Trigger the camera shake animation
        camAnim.SetTrigger("shake");

        // Instantiate the effects at the enemy's position
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(effectTwo, transform.position, Quaternion.identity);

        // Destroy the enemy game object
        Destroy(gameObject);
    }

    // Method to restart the game
    public void Restart()
    {
        // Trigger the camera shake animation
        camAnim.SetTrigger("shake");

        // Instantiate the second effect at the enemy's position
        Instantiate(effectTwo, transform.position, Quaternion.identity);

        // Start the coroutine to wait before restarting the game
        StartCoroutine(WaitBeforeRestart());
    }

    // Coroutine to wait for a specified time before restarting the game
    IEnumerator WaitBeforeRestart()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
