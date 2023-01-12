using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game
using UnityEngine.UI; // For our button interaction

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // List that stores the objects..

    private float spawnRate = 1.0f; // Spawn rate of the objects in our game..

    // Create Text Mesh Pro and Score Variables
    public TextMeshProUGUI scoreText;
    private int score;

    // Create a reference to the gameOverText
    public TextMeshProUGUI gameOverText;

    public bool isGameActive; // Reference for when the game is active or not

    // Reference for the button
    public Button restartButton;

    // Reference to title screen gameObject
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive) // Then we will initialize the spawning through a while loop..
        {
            yield return new WaitForSeconds(spawnRate); // Wait for a second before spawning again.

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]); // Then instantiate every element on that list randomly..
        
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + score; // Then add score to the text.
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // This will Reload our scene everytime we press restart or play again button.
    }

    public void StartGame(float difficulty) // Starts our game..
    {
        // Order of initalization matters.
        isGameActive = true;
        score = 0; // Initialize score here

        spawnRate /= difficulty; // Divides our spawn rate by our difficulty set..

        StartCoroutine(SpawnTarget()); // Then start the coroutine to spawn...
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false); // Turn off the Title screen after picking difficulty..
    }    
}
